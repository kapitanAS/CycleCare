'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Customer
    Public Property CustomerID As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property AddressID As Integer
    Public Property LastUpdate As Nullable(Of Date)

    Public Overridable Property Address As Address
    Public Overridable Property BicycleToCustomersMappings As ICollection(Of BicycleToCustomersMapping) = New HashSet(Of BicycleToCustomersMapping)
	' dodaje tutaj nowa klase
	' blah
	' blah
	' end
End Class
