   M S B A M L   `   `   `  ����G  COceana (WPF), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Oceana__WPF_Oceana__WPF_  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	          Oceana__WPF_.Prescription   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Oceana__WPF_     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      0sys&clr-namespace:System;assembly=mscorlib  5	         MaterialDesignBody#���   5
      $��Medium"�5        MaterialDesignPaper#���  5      $��14(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5      $��16(�5      $	��700��6   $	��300��6(    � 	Resources 5      #   Oceana__WPF_.ObserveTreatment  	Treatment  cvsTreatment �� Source#   Oceana__WPF_.ObservableDoctor 
 doctor  	cvsDoctor!   Oceana__WPF_.ObservePatient  pesakit  
cvsPesakit"   Oceana__WPF_.ObservableNurse 		 nurse 
 cvsNurse3   -Oceana__WPF_.ObservablePrescriptionTreatments  PrescriptionTreatement  cvsPrescriptionTreatment��%O  &	       &	      7  &	 +     &	 >     7  &	 V     &	 i     7  &		 �     &	
 �     7 	 &	 �     &	 �     7    5   
   6!   �� 5   
   8   64     5   
   6!   �� 5   
   8   61     5   
   6   �� 5   
   8   62     5   
   6    �� 5   
   8   60     5   
   61   �� 5   
   8   6@   5      .��5!      � .+�5#   
   7  1MaterialDesignThemes.Wpf.Transitions.Transitioner  !   AutoApplyTransitionOrigins .  �� SelectedIndex$ 0��6H   .@�5%      <  6MaterialDesignThemes.Wpf.Transitions.TransitionerSlide     ForwardWipe 5'      4	  .MaterialDesignThemes.Wpf.Transitions.SlideWipe	  5(       	  	Direction$ Right=�6/   .��5+      #
  MaterialDesignThemes.Wpf.Card
   
  UniformCornerRadius$ 8Q�6'   .��5-      � .+�50      � $��0,20,0,0q�6   $��Center=�61   $��Center=�6N   	 � RowDefinitions	 52      �� 53   "   $
��AUTO �60   �� 54   "   $
��AUTO �60   �� 55   "   $
��AUTO �60   �� 56   "   $
��AUTO �60   �� 57   "   $
��AUTO �60   �� 58   "   $
��AUTO �60   
 � ColumnDefinitions
 5;      �� 5<   "   $
��AUTO �63   �� 5=   "   $
��AUTO �63   �� 5>   "   $
��AUTO �63   .+�5B      �� $��	10,10,0,5q�6(   $��Doctor Incharge��6;   �� 5C      $��1��6(   $��	10,10,0,5q�65   $��Patient Name��6H   �� 5D      $��2��6(   $��	10,10,0,5q�65   $
��Date��6H   �� 5E      $��3��6(   $��	10,10,0,5q�65   $��Disease��6H   �� 5F      $��4��6(   $��	10,10,0,5q�65   $��Nurse Incharge��6H   �� 5I      $��1��6(   $��
10,11,10,5q�68   $��:��6L   �� 5J      $��1��6(   $��1��68   $��
10,10,10,5q�6E   $��:��6Y   �� 5K      $��1��6(   $��2��68   $��
10,10,10,5q�6E   $��:��6Y   �� 5L      $��1��6(   $��3��68   $��
10,10,10,5q�6E   $��:��6Y   �� 5M      $��1��6(   $��4��68   $��
10,10,10,5q�6E   $��:��6Y   �� 5P      -   5         ��Name$ 	cbbDoctor��5P   (   $��2��6;    �� DisplayMemberPath$ 	FirstName��6�   $��7,6,0,0q�6�   $��14(�6�   ��6L   ��  �� Source# [ 6�   �� 5Q      -   5        $ 
cbbPatient��5Q   '   $��1��6;   $��2��6H   $��7,4,0,0q�6X   $ 	FirstName��6�   $��14(�6�   ��6i   �� # [ 6�   (  "System.Windows.Controls.DatePicker  5R      -   5        $��cbbDate��5R   G   $��2��6V   $��2��6c   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Pick Date��6s   $��7,8,0,3q�5S         SelectedDate 5R   )   �� *Hari+5S      �� 5T      -   5         ��Name$ 
txtDisease��5T   &   $��2��6:   $��3��6J   $��7,7,0,0q�6W   �� 5U      -   5        $ cbbNurse��5U   (   $��2��6:   $��4��6J   $ 	FirstName��6�   $��7,6,0,0q�6�   $��14(�6�   ��6X   �� # [
 6�   �� 5X      $��2��6)   $��5��69    �� Orientation$ 
Horizontal=�6F   $
��0,20q�6_   .+�5Z   "   �� $��6��6)   $��2��66   $��0,0,20,0q�6F   $	��100��6X     MaterialDesignRaisedButton#���  5[   !   $��DISCARD��6V   )  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z 5\   !   �� 5]   "   -   5         ��Name$ btnNext��5]   C   $
��True��6*   $
��NEXT��6T   $��Right=�6c   #���  5^   "   $	��100��5_   "   5a      5c      '  !MaterialDesignThemes.Wpf.Snackbar  5e      -   5          Name$ 
MySnackbar��5e   2      MessageQueue 6F   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  5f      5h      5j        5l      .��5n      � 	 5p      �� 5q      $
��AUTO �6(   �� 5r      $��* �6(   .+�5u      � $��	15,15,0,0q�6   
 5w      �� 5x      $
��AUTO �6/   �� 5y      $
��AUTO �6/   �� 5z      $
��AUTO �6/   �� 5{      $��* �6/   .+�5~      �� .+�5�      �� $��Select Treatment��6(   $��Center=�6@   $	��5,5q�6[   �� 5�      $��Instruction��6(   $��Center=�6;   $��5,13,5,0q�6V   5�      �� 5�      $��1��6%   .+�5�      �� $��:��6(   $��1��61   $	��5,5q�6A   $��Center=�6N   �� 5�      $��:��6(   $��1��61   $��5,13,5,0q�6A   $��Center=�6S   5�      �� 5�      $��2��6%   .+�5�      �� -   5        $ cbbTreatment��5�   L   $	��150��5�   '   $	��5,0q�63    �� 
IsEditable .  �� 
IsReadOnly .  $
 Name��5�   d   ��6'   �� # [ 6d   �� 5�      -	   5        $ txtDescription��5�   &   $	��5,8q�6>   5�      �� 5�      $��Right=�6%   $ 
Horizontal=�6A   $	��Top=�6Z   $
��0,10q�6r   $��3��6�   .+�5�      �� -
   5        $ 	btnInsert��5�   8   {�.  $��INSERT��6K   $��90��6\   �� 5�      -   5        $ 	btnRemove��5�   &   $��REMOVE��69   $��90��6J   $��20,0,0,0q�6U   �� 5�      -   5        $ btnSave��5�   �   $
��True��6&   #��Z 6>   $��	20,0,10,0q�6�   $
��SAVE��6�   $��90��6�   5�      5�      
  5�      $��1��6*   $��15q�67   ���#ECEFF1$ 8Q�6X   .��5�      &   System.Windows.Controls.DataGrid  -   5          Name$ dgTreatment��5�   3      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6#      CanUserSortColumns .    SelectionMode$ Extended=�5�   #      CanUserAddRows .     CanUserReorderColumns .     AutoGenerateColumns .  -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 13 8 8 8q�5�   #       ColumnHeaderPadding$  8q�5�   #   $��18(�5�   #   !   
IsReadOnly! . ��6C   �� # [ "   ColumnHeaderStyle" 5�      �� 5�   "    & "MaterialDesignDataGridColumnHeader# �� BasedOn## [ 6(   $ �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"$  6f   .�5�   &   �� % �� Property% � ��& �� Value$& 16(�6A   �� 5�   &   % � ��& �#ECEFF16C   5�   #   '   Columns' 5�      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5�   "   ,  &System.Windows.Controls.DataGridColumn(   Header$( 	Treatment��6D   )   	MaxLength$	) 255��5�   &   1  +System.Windows.Controls.DataGridBoundColumn*   Binding* 5�   &   �� *TreatmentName+5�   &     5�   "   $( Description��6D   $	) 255��5�   &   * 5�   &   �� *Description+5�   &   5�      5�        5�      -   5        $ MySnackbarTwo��5�   .   $��1��6r   $��Stretch=�5�   "   $��Bottom=�6@   $��Center=�6[    5�   E     5�   [   5�      5�      5�      5�      5�      