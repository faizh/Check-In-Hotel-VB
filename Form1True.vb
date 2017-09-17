Public Class CheckIn
    Dim Tarif_Extra, Biaya_Extra, Total_Biaya As Single

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        End
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        tNo.Clear()
        tNama.Clear()
        tTelp.Clear()
        tLama.Clear()
        tJenisKamar.Clear()
        tNamaKamar.Clear()
        tTarifKamar.Clear()
        tBiayaKamar.Clear()
        tJmlExtra.Clear()
        tBiayaExtra.Clear()
        tHargaExtra.Clear()
        tTotal.Clear()
        btnInput.Focus()

    End Sub

    Private Sub btnInput_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInput.Click
        tNo.Focus()
    End Sub

    Private Sub tNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tNo.KeyPress
        If e.KeyChar = Chr(13) Then
            tNama.Focus()
        End If
    End Sub

    Private Sub tNama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tNama.KeyPress
        If e.KeyChar = Chr(13) Then
            tTelp.Focus()
        End If
    End Sub

    Private Sub tTelp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tTelp.KeyPress
        If e.KeyChar = Chr(13) Then
            dtpMasuk.Focus()
        End If
    End Sub

    Private Sub CheckIn_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        dtpMasuk.Value = Date.Today
        dtpKeluar.Value = Date.Today
    End Sub

    Private Sub dtpMasuk_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpMasuk.CloseUp
        tLama.Focus()
    End Sub

    Private Sub dtpMasuk_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpMasuk.KeyPress
        If e.KeyChar = Chr(13) Then
            tLama.Focus()
        End If
    End Sub

    Private Sub tLama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tLama.KeyPress
        If e.KeyChar = Chr(13) Then
            dtpKeluar.Value = DateAdd(DateInterval.Day, Val(tLama.Text), dtpMasuk.Value)
            btnPilih.Focus()
        End If
    End Sub

    Private Sub btnPilih_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPilih.Click
        Me.Enabled = False
        Form_PilihKamar.Show()

    End Sub

    Private Sub rbBed_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            tJmlExtra.Enabled = True
            tJmlExtra.Focus()
        End If
    End Sub

    Private Sub rbFan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            tJmlExtra.Enabled = True
            tJmlExtra.Focus()
        End If
    End Sub

    Private Sub rbBedFan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            tJmlExtra.Enabled = True
            tJmlExtra.Focus()
        End If
    End Sub

    Private Sub rbTidak_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            tJmlExtra.Enabled = False
            Total_Biaya = Biaya_Kamar
            tTotal.Text = Format(Total_Biaya, "Rp #,#.00")
            btnClose.Focus()
        End If
    End Sub

    Private Sub tJmlExtra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            If rbBed.Checked = True Then
                Tarif_Extra = 200000
            ElseIf rbFan.Checked = True Then
                Tarif_Extra = 100000
            ElseIf rbBedFan.Checked = True Then
                Tarif_Extra = 250000
            Else
                Tarif_Extra = 0
            End If
            tHargaExtra.Text = Format(Tarif_Extra, "Rp #,#.00")
            Biaya_Extra = Tarif_Extra * Val(tJmlExtra.Text)
            tBiayaExtra.Text = Format(Biaya_Extra, "Rp #,#.00")
            Total_Biaya = Biaya_Kamar + Biaya_Extra
            tTotal.Text = Format(Total_Biaya, "Rp #,#.00")
            btnClose.Focus()
        End If
    End Sub
End Class
