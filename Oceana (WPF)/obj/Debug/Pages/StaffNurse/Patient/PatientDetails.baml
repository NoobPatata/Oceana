   M S B A M L   `   `   `  ����G  COceana (WPF), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Oceana__WPF_Oceana__WPF_  5      !    Oceana__WPF_.PatientDetails   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Oceana__WPF_     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	      $��Medium"�5
        MaterialDesignPaper#���  5      $��14(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5      $	��800��5      $	��600��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��AUTO �6   �� 5      $��* �6   .+�5   
   ��  $  MaterialDesignHeadline5TextBlock#��[ 6   $��Patient Profile��5      $��Center=�5      $��0,10,0,0q�5      $��1��5      � 5   
   $��1��6   $��2��6    5       �� 5!      $
��3.5* �6    �� 5"      $��1* �6    .+�5%      �  � ColumnDefinitions 5&      �� 5'      $��1* �6'   �� 5(      $��1* �6'    5+      �� 5,      $
��Auto �6$   �� 5-      $
��Auto �6$   �� 5.      $
��Auto �6$   �� 5/      $
��Auto �6$   �� 50      $
��Auto �6$   �� 51      $
��Auto �6$   �� 52      $
��Auto �6$   �� 53      $
��Auto �6$   .+�57      �� $��Basic Information��6   $
��20,5q�58      $��	Underline{�6*   �� 5;      $��1��6   .+�5<      �� -   5         ��Name$ txtPID��5<   a    �� 
IsReadOnly . $��1��60    % !MaterialDesignFloatingHintTextBox#��[ 5=      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Patient ID��5>      $
��20,5q�5?      ��5<   =   �� *EPatient.PatientID+5?      �� 5@      -   5        $ txtFirstName��5@   c   $��3��6   #��[ 5A      $ 
First Name��5B      $
��20,5q�5C      ��5@   +   �� *FN+ �� UpdateSourceTrigger$ PropertyChanged=�5C      5D      �� 5G      $��1��6   $��1��6-   .+�5H      �� -   5        $ txtIC��5H   c   $��2��6   #��[ 5I      $ Identification Number��5J      $
��20,5q�5K      ��5H   +   �� *ID+$ PropertyChanged=�5K      �� 5L      -   5        $ txtLastName��5L   d   $��4��6   #��[ 5M      $ 	Last Name��5N      $
��20,5q�5O      ��5L   +   �� *LN+$ PropertyChanged=�5O      5P      �� 5S      $��2��6   $��Contact Information��6)   $��	20,10,0,5q�5T      $��	Underline{�6/   �� 5W      $��3��6   .+�5X      �� -   5        $ txtPhone��5X   c   $��5��6   #��[ 5Y      $ Phone Number��5Z      $
��20,5q�5[       �� 	MaxLength$ 11��5\      ��5X   +   �� *CN+$ PropertyChanged=�5\      �� 5^      $��3��6"   .+�5_      �� -   5        $ 
txtAddress��5_   g   $��7��6"   #��[ 5`      $ Address��5a      $
��20,5q�5b      	 �� TextWrapping$
	 Wrap=�5c      ��5_   /   �� *AD+$ PropertyChanged=�5c      5d      5e      �� 5h      $��1��6   $��3��6-   .+�5i      �� -   5        $ txtEmail��5i   c   $��6��6   #��[ 5j      $ Email��5k      $
��20,5q�5l      ��5i   +   �� *EM+$ PropertyChanged=�5l      5m      �� 5p      $��4��6   $��Basic Health Information��6)   $��	20,10,0,5q�5q      $��	Underline{�6/   �� 5t      $��5��6   .+�5u      �� -   5        $ 	txtHeight��5u   c   $��8��6   #��[ 5v      $ Height��5w      $
��20,5q�5x      ��5u   +   �� *CM+$ PropertyChanged=�5x      �� 5y      -	   5        $ txtAllergies��5y   e   $��10��6   #��[ 5z      $ 	Allergies��5{      $
��20,5q�5|      ��5y   -   �� *AL+$ PropertyChanged=�5|      5}      �� 5�      $��1��6   $��5��6-   .+�5�      �� -
   5        $ 	txtWeight��5�   c   $��9��6   #��[ 5�      $ Weight��5�      $
��20,5q�5�      ��5�   +   �� *KG+$ PropertyChanged=�5�      �� 5�      -   5        
 ��Name$
 cbbBloodType��5�   Y   $��11��6    & "MaterialDesignFloatingHintComboBox#��[ 5�      $ 	BloodType��5�      $
��20,5q�5�       �� SelectedItem 5�   -   �� *EPatient.BloodType+5�      5�      5�      �� 5�      $��1��6   $��Center=�6&   $��Center=�6B    �� Orientation$ 
Horizontal=�5�      .+�5�      �� $��12��6   )  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z 6M   $
��True��6�   $��80��6�   $��40��6�   $
��25,5q�6�   $
��Save��6�   {�6'   �� *AllFieldsFilled+6�   �� 5�      $��13��6   #��Z 6'   $��False��6i   $��80��6�   $��40��6�   $
��25,5q�6�   $��Discard��6�   5�      5�      5�      5�      