   M S B A M L   `   `   `  ����G  COceana (WPF), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Oceana__WPF_Oceana__WPF_  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	          Oceana__WPF_.Patients   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Oceana__WPF_     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      0sys&clr-namespace:System;assembly=mscorlib  5	         MaterialDesignBody#���   5
      $��Medium"�5        MaterialDesignPaper#���  5      $��14(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5      $��16(�5       � 	Resources 5      !   Oceana__WPF_.ObservePatient  patients  cvsPatients �� Source)   #Oceana__WPF_.ObservablePrescription  prescription  cvsPrescription��%�   &	       &	      7  &	 +     &	 >     7    5   
   6   �� 5   
   8   63     5   
   6'   �� 5   
   8   67   5      .��5      )  #MaterialDesignThemes.Wpf.DialogHost     
Identifier$ 
RootDialog��6       DialogContent 5   
   � 5      .+�5       ��    CloseDialogCommand#��Z 6   ��5!      ��5"      True��5$      5&      �� 5'      #��Z 6   ��5(      ��5)      	False��5+      5-      5.      .��51   
   �  � RowDefinitions 53      �� 54      $
��AUTO �6    �� 55      $
��AUTO �6    �� 56      $��* �6    .+�59      �  � ColumnDefinitions 5;      �� 5<      $
��AUTO �6'   �� 5=      $��* �6'   .+�5A      �� 	 �� Orientation$	 
Horizontal=�6   $��20,20,20,10q�66   .+�5B      '  !MaterialDesignThemes.Wpf.PackIcon  $��1��6.   
   Kind$
 Search=�6<   $��30��6J   $��30��6U   $��	15,0,10,0q�6a   $��Center=�6t   �� 5C      -   5         ��Name$ 	txtSearch��5C      $��1��61   $��1��6>   $��Center=�6N   $	��250��5D   "   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ SEARCH PATIENT��6.   $��15(�6_   5E      �� 5G      -   5         ��Name$ btnAdd��5G      $
��20,0q�6)   $��1��67   $��ADD PRESCRIPTION��6G   $��Center=�6b    $  MaterialDesignRaisedAccentButton#���  5H      $	��160��5I      $��Right=�6%   5K      � 5P      $��1��6   $��
20,0,20,10q�6     5R      �� 5S      $
��AUTO �6/   �� 5T      $
��AUTO �6/   �� 5U      $��* �6/   .+�5Z      �� .+�5[      �� $��
Patient ID��6(   $��
20,10,10,5q�6:   $��Center=�5\   (   �� 5]      $��Patient Name��6(   $
��20,5q�6<   $��Center=�5^   (   �� 5_      $��
Blood Type��6(   $
��20,5q�6:   $��Center=�5`   (   �� 5a      $��	Allergies��6(   $
��20,5q�69   $��Center=�5b   (   5c      �� 5f      $��1��6%   .+�5g      �� $��0,9,0,5q�6(   $��:��69   �� 5h      $	��0,5q�6(   $��:��65   �� 5i      $	��0,5q�6(   $��:��65   �� 5j      $	��0,5q�6(   $��:��65   5k      �� 5o      $��2��6%   .+�5p      �� -   5         ��Name$	 PID��5p   '   ��64   ��  �� Source# [ ��5q      �� 5r   "   .R�5s   &   �� $��	10,10,0,5q�6R   $��Center=�5t   ,   ��5s   1   ��  �� Path$ 	PatientID�5t   ,   5u   #   5w      �� 5x      -   5        $ FN��5x   '   ��63   �� # [ ��5y      �� 5z   "   .R�5{   &   �� $
��10,5q�6O   $��Center=�5|   ,   ��5{   0   �� $ Fullname�5|   ,   5}   #   5      �� 5�      -   5        $ BT��5�   '   ��63   �� # [ ��5�      �� 5�   "   .R�5�   &   �� $
��10,5q�6P   $��Center=�5�   ,   ��5�   0   �� $ 	BloodType�5�   ,   5�   #   5�      �� 5�      -   5        $ AL��5�   '   ��63   �� # [ ��5�      �� 5�   "   .R�5�   &   �� $
��10,5q�6P   $��Center=�5�   ,   ��5�   0   �� $ 	Allergies�5�   ,   5�   #   5�      5�      5�      #  MaterialDesignThemes.Wpf.Card  5�      $��2��6"   ���#ECEFF1$��10q�5�   "      UniformCornerRadius$ 10Q�6.   .��5�      &   System.Windows.Controls.DataGrid  -   5          Name$ dgRecord��5�   +      ColumnWidth5	  /System.Windows.Controls.DataGridLengthConverter$ *	 6      CanUserSortColumns .    SelectionMode$ Extended=�5�         CanUserAddRows .     CanUserReorderColumns .     AutoGenerateColumns .  -
  'MaterialDesignThemes.Wpf.DataGridAssist 
  CellPadding$ 13 8 8 8q�5�       
  ColumnHeaderPadding$ 8q�5�      $��18(�5�         
IsReadOnly . ��5�      �� # [    ColumnHeaderStyle 5�      �� 5�       & "MaterialDesignDataGridColumnHeader �� BasedOn# [ 6$    �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6b   .�5�   !   ��  �� Property � ��  �� Value$  16(�6<   �� 5�   !    � ��  �#ECEFF16>   5�      !   Columns! 5�      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5�   &   ,  &System.Windows.Controls.DataGridColumn"   Header$" Prescription ID��5�   &   #   	MaxLength$	# 255��5�   &   1  +System.Windows.Controls.DataGridBoundColumn$   Binding$ 5�   &   �� *PrescriptionID+5�   &     5�   &   $
" Date��5�   &   $	# 255��5�   &   $ 5�   &   �� *Hari+5�   &     5�   &   $" Doctor Incharge��5�   &   $	# 255��5�   &   $ 5�   &   �� *	DFullname+5�   &     5�      $" Disease��5�   &   $	# 255��5�   &   $ 5�   &   �� *	Disease+5�   &   5�      5�      '  !MaterialDesignThemes.Wpf.Snackbar  5�      -   5        %  Name$% 
MySnackbar��5�   &   $��2��6g   $��Stretch=�5�   "   $��Bottom=�6@   $��Center=�6[   &   MessageQueue& 5�   :   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  5�   [   5�      5�      5�      