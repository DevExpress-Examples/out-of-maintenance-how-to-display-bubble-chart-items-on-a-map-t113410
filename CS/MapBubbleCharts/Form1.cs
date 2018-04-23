using DevExpress.XtraMap;
using System.Data;
using System.Windows.Forms;

namespace MapBubbleCharts {
    public partial class Form1 : Form {
        string dataPath = @"..\..\Earthquakes.xml";
        int minMagnitude = 6;
        int maxMagnitude = 10;

        VectorItemsLayer BubbleLayer { get { return (VectorItemsLayer)mapControl1.Layers[1]; } }

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e) {
            BubbleLayer.Data = CreateData();

            // Create a size legend and define meanings for bubble sizes.
            mapControl1.Legends.Add(new SizeLegend() {
                Layer = BubbleLayer,
                Header = "Magnitude"
            });
        }

        private IMapDataAdapter CreateData() {
            BubbleChartDataAdapter adapter = new BubbleChartDataAdapter() {
                DataSource = LoadData()
            };

            // Map the properties of chart items to the appropriate fields in the data source.
            adapter.Mappings.Latitude = "glat";
            adapter.Mappings.Longitude = "glon";
            adapter.Mappings.BubbleGroup = "Type";
            adapter.Mappings.Value = "mag";
            
            adapter.MeasureRules = CreateMeasureRules();

            // Customize other chart adapter properties.
            adapter.ItemMaxSize = 60;
            adapter.ItemMinSize = 10;

            return adapter;
        }

        private DataTable LoadData() {
            DataSet ds = new DataSet();
            ds.ReadXml(dataPath);
            DataTable dt = ds.Tables[0];
            dt.DefaultView.RowFilter = string.Format("(mag >= {0}) AND (mag <= {1})", minMagnitude, maxMagnitude);

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

    }
}
