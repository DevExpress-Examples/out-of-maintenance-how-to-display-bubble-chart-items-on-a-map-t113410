using DevExpress.XtraMap;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace MapBubbleCharts {
    public partial class Form1 : Form {
        string dataPath = @"..\..\Earthquakes.xml";
        int minMagnitude = 6;
        int maxMagnitude = 10;

        VectorItemsLayer BubbleLayer { get { return (VectorItemsLayer)mapControl1.Layers["BubbleLayer"]; } }

        public Form1() {
            InitializeComponent();

            #region #DataProperty
            // Specify data for the bubble layer.
            BubbleLayer.Data = CreateData();
            #endregion #DataProperty
        }

        #region #CreateData
        private IMapDataAdapter CreateData() {
            BubbleChartDataAdapter adapter = new BubbleChartDataAdapter() {
                DataSource = LoadData(),
                MeasureRules = CreateMeasureRules(),
                ItemMaxSize = 60,
                ItemMinSize = 10
            };

            #region #Mappings
            // Map the properties of chart items to the appropriate fields in the data source.
            adapter.Mappings.Latitude = "glat";
            adapter.Mappings.Longitude = "glon";
            adapter.Mappings.Value = "mag";
            #endregion #Mappings

            // Create attribute mappings to provide additional information about map items to the map.
            adapter.AttributeMappings.Add(new MapItemAttributeMapping("Magnitude", "mag"));
            adapter.AttributeMappings.Add(new MapItemAttributeMapping("Year", "yr"));
            adapter.AttributeMappings.Add(new MapItemAttributeMapping("Month", "mon"));
            adapter.AttributeMappings.Add(new MapItemAttributeMapping("Day", "day"));
            adapter.AttributeMappings.Add(new MapItemAttributeMapping("Depth", "dep"));

            return adapter;
        }

        private DataTable LoadData() {
            DataSet ds = new DataSet();
            ds.ReadXml(dataPath);
            DataTable dt = ds.Tables[0];
            dt.DefaultView.RowFilter = string.Format(CultureInfo.InvariantCulture, "(mag >= {0}) AND (mag <= {1})", minMagnitude, maxMagnitude);

            return ds.Tables[0];
        }

        private MeasureRules CreateMeasureRules() {
            MeasureRules measureRules = new MeasureRules();

            measureRules.ApproximateValues = true;
            measureRules.RangeDistribution = new LinearRangeDistribution();

            for (int i = minMagnitude; i < maxMagnitude; i++) {
                measureRules.RangeStops.Add(i);
            }

            return measureRules;
        }
        #endregion #CreateData
    }
}
