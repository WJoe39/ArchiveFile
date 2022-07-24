Module ArchiveFile
#Region "Head"
    '******************************************************************************
    '*  MODULE        : ArchiveFile
    '*  FILE          : ArchiveFile.vb
    '*  PROJECT       : ArchiveFile
    '*  AUTHOR        : Christoph A. Lutz
    '*  CREATED       : 02-Dec-2005
    '*  COPYRIGHT     : Copyright (c) 2005-2009 Christoph A. Lutz.
    '*                  All Rights Reserved.
    '*
    '*                  This module is free software; you can redistribute it
    '*                  and/or modify it under the terms of the GNU General
    '*                  Public License as published by the Free Software
    '*                  Foundation; either version 2 of the License, or any later
    '*                  version.
    '*
    '*                  All copyright notices regarding Chris A. Lutz must remain
    '*                  intact in the source code and in the outputted text.
    '*
    '*                  This program is distributed in the hope that it will be
    '*                  useful, but WITHOUT ANY WARRANTY; without even the implied
    '*                  warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR
    '*                  PURPOSE. See the GNU General Public License for more details.
    '*
    '*  DESCRIPTION   : File archiving command line tool
    '*
    '*  MODIFICATION HISTORY:
    '*  AUTHOR:             DATE:       CHANGES:
    '*  Christoph A. Lutz   02-Dec-2005 Initial Version
    '*
    '******************************************************************************
#End Region
#Region "Declaration"
#End Region
#Region "Properties"
#End Region
#Region "Methods"
    Sub Main()
        'TODO copperplate

        Dim sSeparator As String
        Dim sCmdParameter As String
        Dim sParameter() As String

        Dim sFilePath As String
        Dim sFileName As String

        Dim sNewFile As String
        Dim sOldFile As String
        Dim sPrefix As String

        Dim iCounter As Integer

        '   Error handling
        On Error Resume Next

        '   Keine Parameter -> Ende
        sCmdParameter = Command()
        If sCmdParameter = "" Then
            ShowUsage()
            End
        End If

        '   Parameter auslesen
        sSeparator = " "
        sParameter = sCmdParameter.Split(sSeparator.ToCharArray, 3)
        ReDim Preserve sParameter(2)

        If sParameter(0) = "" Then
            ShowUsage()
            End
        End If
        If Dir(sParameter(0)) = "" Then
            Console.WriteLine("Source file does not exist!")
            End
        End If
        If sParameter(1) = "" Then
            sParameter(1) = "10"
        End If
        If sParameter(2) = "" Then
            sParameter(2) = "n"
        End If

        SplitPath(sParameter(0), sFilePath, sFileName)

        '   Alte Dateien löschen
        For iCounter = 1000 To CInt(sParameter(1)) Step -1
            If sParameter(2).ToUpper = "N" Then
                sPrefix = iCounter.ToString("0000")
            Else
                sPrefix = DateAdd(DateInterval.Day, (iCounter * -1), Now).ToString("yyyyMMdd")
            End If
            sNewFile = sPrefix & "_" & sFileName
            If Dir(SetFilename(sFilePath, sNewFile)) <> "" Then
                Kill(SetFilename(sFilePath, sNewFile))
            End If
        Next iCounter

        '   Numerisch, schieben
        If sParameter(2).ToUpper = "N" Then
            For iCounter = CInt(sParameter(1)) To 1 Step -1
                sOldFile = (iCounter - 1).ToString("0000") & "_" & sFileName
                sNewFile = iCounter.ToString("0000") & "_" & sFileName
                If Dir(SetFilename(sFilePath, sOldFile)) <> "" Then
                    FileCopy(SetFilename(sFilePath, sOldFile), SetFilename(sFilePath, sNewFile))
                End If
            Next iCounter
        End If

        '   Dateikopie anlegen
        If sParameter(2).ToUpper = "N" Then
            sPrefix = "0000"
        Else
            sPrefix = Now.ToString("yyyyMMdd")
        End If
        sNewFile = sPrefix & "_" & sFileName
        FileCopy(SetFilename(sFilePath, sFileName), SetFilename(sFilePath, sNewFile))

    End Sub

    Private Sub ShowUsage()
        'TODO copperplate

        '   Error handling
        On Error Resume Next

        Console.WriteLine("Copyright (C) 2005-2010 Chris A. Lutz.")
        Console.WriteLine("ArchiveFile Version " & _
                          System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileVersion & ". Usage:")
        Console.WriteLine("ArchiveFile <Source file> [Number of instances] [Enumeration method]")
        Console.WriteLine(" ")
        Console.WriteLine("<Command>")
        '                  *******************************************************************************
        Console.WriteLine(" Source file               Full path to the file you want to archive. If you ")
        Console.WriteLine("                           just give the file name we assume it's in the local")
        Console.WriteLine("                           directory.")
        Console.WriteLine(" Number of instances       (Optional) How many instances will be kept.")
        Console.WriteLine("                           Default is 10.")
        Console.WriteLine(" Enumeration method [d,n]  (Optional) Date (d) or sequential number (n).")
        Console.WriteLine("                           Default is n.")
        Console.ReadLine()
    End Sub

    Private Sub SplitPath(ByVal sFullPath As String, _
                          ByRef sFilePath As String, _
                          ByRef sFileName As String)

        '**********************************************************************
        ' SplitPath (SUB/PROCEDURE)
        '
        '  PURPOSE      : Trennt Dateiname und Ordnerpfad aus einem volen Pfad
        '  PARAMETERS   : (IN) sFullPath(String) - Voller Pfad
        '                 (OUT) sFilePath(String) - Ordner als Speicherort
        '                 (OUT) sFileName(String) - Dateiname
        '                 
        '  RETURN VALUE : -
        '
        '**********************************************************************

        Dim iPointer As Integer

        '   Error handling
        On Error Resume Next

        iPointer = InStrRev(sFullPath, "\", -1, CompareMethod.Text)
        If iPointer < 1 Then
            sFilePath = ""
            sFileName = sFullPath
        Else
            sFilePath = sFullPath.Substring(0, iPointer)
            sFileName = sFullPath.Substring(iPointer)
        End If

    End Sub
    Private Function SetFilename(ByVal sFilePath As String, _
                                 ByVal sFileName As String) As String

        '**********************************************************************
        ' SetFilename (FUNCTION)
        '
        '  PURPOSE      : Ermittelt den vollen Pfad inklusive des Dateinamens
        '  PARAMETERS   : (IN) sFilePath(String) - Ordner als Speicherort
        '                 (IN) sFileName(String) - Dateiname
        '  RETURN VALUE : Voller Pfad
        '
        '**********************************************************************

        Dim sPath As String

        '   Error handling
        On Error Resume Next

        sPath = sFilePath
        If Not (sPath.EndsWith("\") Or sFileName.StartsWith("\")) Then
            sPath = sPath & "\"
        End If

        sPath = sPath & sFileName

        Return sPath

    End Function
#End Region
End Module
