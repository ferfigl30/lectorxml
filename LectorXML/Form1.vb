Imports System.Xml

Public Class frmLectorXML

    Private Sub btnLeerXML_Click(sender As Object, e As EventArgs) Handles btnLeerXML.Click
        Dim nsCFDi As XNamespace = "http://www.sat.gob.mx/cfd/3"

        Try
            OpenFileDialog1.Filter = "archivo XML|*.xml"
            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'Dim documentoXML As XDocument = XDocument.Load("C:\Users\sistemas\Documents\FFL\CLIENTES\GACSE\Ejemplo impuesto Trasladado.xml")
                Dim documentoXML As XDocument = XDocument.Load(OpenFileDialog1.FileName)
                Dim documentoXML2 As XmlDocument
                documentoXML2 = New XmlDocument()
                documentoXML2.Load(OpenFileDialog1.FileName)
                'documentoXML2.Load("C:\Users\sistemas\Documents\FFL\CLIENTES\GACSE\Ejemplo impuesto Trasladado.xml")

                Dim total As String
                total = documentoXML2.DocumentElement.GetAttribute("Total").ToString
                MsgBox("El total es: " + total)

                For Each ldocumento As XElement In documentoXML.Descendants(nsCFDi + "Comprobante").Elements()
                    Dim tipo As String = ldocumento.Name.LocalName.ToString
                    'Dim nombre2 As String = ldocumento
                    If tipo = "Emisor" Or tipo = "Receptor" Then
                        Dim rfc1 As String = ldocumento.Attribute("Rfc").Value
                        MsgBox("RFC " + tipo + ": " + rfc1)
                    End If

                Next
            End If

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
End Class
