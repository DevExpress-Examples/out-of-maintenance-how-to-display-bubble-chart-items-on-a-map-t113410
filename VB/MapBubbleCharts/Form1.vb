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
                Return CType(mapControl1.Layers("BubbleLayer"), VectorItemsLayer)
            End Get
        End Property

        Public Sub New()
            InitializeComponent()

'            #Region "#DataProperty"
            ' Specify data for the bubble layer.
            BubbleLayer.Data = CreateData()
'            #End Region ' #DataProperty
        End Sub

        #Region "#CreateData"
        Private Function CreateData() As IMapDataAdapter
            Dim adapter As New BubbleChartDataAdapter() With {.DataSource = LoadData(), .MeasureRules = CreateMeasureRules(), .ItemMaxSize = 60, .ItemMinSize = 10}

'            #Region "#Mappings"
            ' Map the properties of chart items to the appropriate fields in the data source.
            adapter.Mappings.Latitude = "glat"
            adapter.Mappings.Longitude = "glon"
            adapter.Mappings.Value = "mag"
'            #End Region ' #Mappings

            ' Create attribute mappings to provide additional information about map items to the map.
            adapter.AttributeMappings.Add(New MapItemAttributeMapping("Magnitude", "mag"))
            adapter.AttributeMappings.Add(New MapItemAttributeMapping("Year", "yr"))
            adapter.AttributeMappings.Add(New MapItemAttributeMapping("Month", "mon"))
            adapter.AttributeMappings.Add(New MapItemAttributeMapping("Day", "day"))
            adapter.AttributeMappings.Add(New MapItemAttributeMapping("Depth", "dep"))

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
        #End Region ' #CreateData
    End Class
End Namespace
