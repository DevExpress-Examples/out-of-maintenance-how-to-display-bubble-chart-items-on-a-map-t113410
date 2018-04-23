Imports DevExpress.XtraMap
Imports System.Data
Imports System.Windows.Forms

Namespace MapBubbleCharts
    Partial Public Class Form1
        Inherits Form

        Private dataPath As String = "..\..\Earthquakes.xml"
        Private minMagnitude As Integer = 6
        Private maxMagnitude As Integer = 10

        Private ReadOnly Property BubbleLayer() As VectorItemsLayer
            Get
                Return CType(mapControl1.Layers(1), VectorItemsLayer)
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            BubbleLayer.Data = CreateData()

            ' Create a size legend and define meanings for bubble sizes.
            mapControl1.Legends.Add(New SizeLegend() With {.Layer = BubbleLayer, .Header = "Magnitude"})
        End Sub

        Private Function CreateData() As IMapDataAdapter
            Dim adapter As New BubbleChartDataAdapter() With {.DataSource = LoadData()}

            ' Map the properties of chart items to the appropriate fields in the data source.
            adapter.Mappings.Latitude = "glat"
            adapter.Mappings.Longitude = "glon"
            adapter.Mappings.BubbleGroup = "Type"
            adapter.Mappings.Value = "mag"

            adapter.MeasureRules = CreateMeasureRules()

            ' Customize other chart adapter properties.
            adapter.ItemMaxSize = 60
            adapter.ItemMinSize = 10

            Return adapter
        End Function

        Private Function LoadData() As DataTable
            Dim ds As New DataSet()
            ds.ReadXml(dataPath)
            Dim dt As DataTable = ds.Tables(0)
            dt.DefaultView.RowFilter = String.Format("(mag >= {0}) AND (mag <= {1})", minMagnitude, maxMagnitude)

            Return ds.Tables(0)
        End Function

        Private Function CreateMeasureRules() As MeasureRules
            Dim measureRules As New MeasureRules()

            measureRules.ApproximateValues = True
            measureRules.RangeDistribution = New LinearRangeDistribution()

            For i As Integer = minMagnitude To maxMagnitude - 1
                measureRules.RangeStops.Add(i)
            Next i

            Return measureRules
        End Function

    End Class
End Namespace
