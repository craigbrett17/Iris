Imports Facebook

Public Class Comment
    Private _commentId As String
    Public ReadOnly Property CommentId() As String
        Get
            Return _commentId
        End Get
    End Property

    Private _fromName As String
    Public ReadOnly Property FromName() As String
        Get
            Return _fromName
        End Get
    End Property

    Private _fromId As String
    Public ReadOnly Property FromId() As String
        Get
            Return _fromId
        End Get
    End Property

    Private _message As String
    Public ReadOnly Property Message() As String
        Get
            Return _message
        End Get
    End Property

    Private _createdTime As DateTime
    Public ReadOnly Property CreatedTime() As DateTime
        Get
            Return _createdTime
        End Get
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal jsonIn As JsonObject)
        _commentId = TryCast(GetJsonValueIfExists(jsonIn, "id"), String)
        _fromId = TryCast(GetJsonValueIfExists(
                DirectCast(GetJsonValueIfExists(jsonIn, "from"), JsonObject),
                "id"), String)
        _fromName = TryCast(GetJsonValueIfExists(
                DirectCast(GetJsonValueIfExists(jsonIn, "from"), JsonObject),
                "name"), String)
        _message = TryCast(GetJsonValueIfExists(jsonIn, "message"), String)
        Dim timeString As String = TryCast(GetJsonValueIfExists(jsonIn, "created_time"), String)
        If Not timeString Is Nothing Then
            _createdTime = DateTime.Parse(timeString)
        End If
    End Sub

    Private Function GetJsonValueIfExists(ByVal jsonIn As JsonObject, ByVal desiredKey As String) As Object
        If jsonIn.ContainsKey(desiredKey) Then
            Return jsonIn(desiredKey)
        Else
            Return Nothing
        End If
    End Function

End Class