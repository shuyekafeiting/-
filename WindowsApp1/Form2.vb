Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button3.Visible = False
        Button4.Visible = False
        If Me.TextBox1.Text = "" Then
            MessageBox.Show("订单号为空")
            Return
        End If

        '清空显示
        bdddzt.Text = ""
        bdflje.Text = ""
        bdpid.Text = ""
        bdxdsj.Text = ""
        bdzhgx.Text = ""

        xsddzt.Text = ""
        xsflje.Text = ""
        xspid.Text = ""
        xsxdsj.Text = ""
        xszhgx.Text = ""


        Dim Postobj As Object = New Postclas
        Dim sign, method, order_sn, times As String

        sign = "jdimport_exe" 'QQ号码
        method = "Pdd.checkTrade" '加密后的QQ密码
        order_sn = TextBox1.Text '验证码
        Dim postData As String = "sign=" & sign & "&method=" & method & "&order_sn=" & order_sn


        Dim re As String = Postobj.Selfpost("http://trade.xfz178.com", postData)
        '解析结果
        Dim p As JObject = CType(JsonConvert.DeserializeObject(re), JObject)
        '错误处理
        If p("code").ToString() = "-1" Then
            MessageBox.Show(p("data").ToString())
            Return
        End If
        '显示信息
        bdddzt.Text = p("own_data")("order_status").ToString()
        bdflje.Text = p("own_data")("promotion_amount").ToString() & "元"
        bdpid.Text = p("own_data")("p_id").ToString()
        bdxdsj.Text = p("own_data")("create_time").ToString()
        bdzhgx.Text = p("own_data")("update_time").ToString()

        '判断是否可以强制返利
        If p("if_lost").ToString() = 1 And p("if_fanli").ToString() = 1 Then
            MessageBox.Show("线上并没有获取到订单信息,可以进行强制返利")
            Button4.Show()
            Return
        ElseIf p("if_lost").ToString() = 1 And p("if_fanli").ToString() = 0 Then
            MessageBox.Show("线上并没有获取到订单信息")
            Return
        End If

        xsddzt.Text = p("online_data")("order_status").ToString()
        xsflje.Text = p("online_data")("promotion_amount").ToString() & "元"
        xspid.Text = p("online_data")("p_id").ToString()
        xsxdsj.Text = p("online_data")("create_time").ToString()
        xszhgx.Text = p("online_data")("update_time").ToString()

        '判断数据是否一致
        If p("if_same").ToString() = "0" Then
            MessageBox.Show("系统检测到该订单线上线下状态不一致,可以进行更新操作")
            Button3.Show()
        End If

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button3.Visible = False
        Button4.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Postobj As Object = New Postclas
        Dim sign, method, order_sn, times As String

        sign = "jdimport_exe" 'QQ号码
        method = "Pdd.changeTrade" '加密后的QQ密码
        order_sn = TextBox1.Text '验证码
        Dim postData As String = "sign=" & sign & "&method=" & method & "&order_sn=" & order_sn


        Dim re As String = Postobj.Selfpost("http://trade.xfz178.com", postData)
        '解析结果
        Dim p As JObject = CType(JsonConvert.DeserializeObject(re), JObject)

        '错误处理
        If p("code").ToString() = "-1" Then
            MessageBox.Show(p("data").ToString())
            Return
        Else
            MessageBox.Show(p("data").ToString())
            Button3.Visible = False
            Return
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Postobj As Object = New Postclas
        Dim sign, method, order_sn, times As String

        sign = "jdimport_exe" 'QQ号码
        method = "Pdd.foceUpdateTrade" '加密后的QQ密码
        order_sn = TextBox1.Text '验证码
        Dim postData As String = "sign=" & sign & "&method=" & method & "&order_sn=" & order_sn


        Dim re As String = Postobj.Selfpost("http://trade.xfz178.com", postData)
        '解析结果
        Dim p As JObject = CType(JsonConvert.DeserializeObject(re), JObject)

        '错误处理
        If p("code").ToString() = "-1" Then
            MessageBox.Show(p("data").ToString())
            Return
        Else
            MessageBox.Show(p("data").ToString())
            Button3.Visible = False
            Return
        End If
    End Sub
End Class