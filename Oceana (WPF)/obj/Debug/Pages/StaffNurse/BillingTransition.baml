   M S B A M L   `   `   `  ����G  COceana (WPF), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Oceana__WPF_Oceana__WPF_  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	      $    Oceana__WPF_.BillingTransition   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Oceana__WPF_     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      0sys&clr-namespace:System;assembly=mscorlib  5	         MaterialDesignBody#���   5
      $��Medium"�5        MaterialDesignPaper#���  5      $��15(�5        MaterialDesignFont#���  5      $��20(�6@     � 	Resources  5      $   Oceana__WPF_.ObservableInvoice  Invoice  
cvsInvoice �� Source&    Oceana__WPF_.ForegroundConverter  conv+   %Oceana__WPF_.ObservableInvoiceDetails  details  
cvsDetails"   Oceana__WPF_.ObservableNurse 	 nurse 	 cvsNurse��%�   &	       &	      7  &	 +     &	 >     &	 Q     7  &	 i     &		 |     7    5   
   6"   �� 5   
   8   62     5   
   6$     5   
   6)   �� 5   
   8   62     5   
   6    �� 5   
   8   60   5      .��5      )  #MaterialDesignThemes.Wpf.DialogHost     
Identifier$ 
RootDialog��6       DialogContent 5   
   � 5      -   5        $��UpdateInvoiceDialog��5   2   $	��450��6   
�������.+�5       �� .+�5!      ��  �� TextAlignment$ Center=�6      
 MaterialDesignBody1TextBlock#��[
 67   $<��6Please make sure all the information given is correct.��5"      $��10q�6R   $	��Top=�6^   �� 5#       �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��Bottom=�6W   $
��0,10q�6r   .+�5$      �� $	��5,0q�6!      CloseDialogCommand#��Z 6.   $
��Next��6p   $��75��6   $��35��6�   ��5%      ��5&   "   True��5(   #   5*      �� 5+      $	��5,0q�6!   #��Z 6.   $��Return��6p   $��75��6�   $��35��6�   ��5,      ��5-   "   	False��5/   #   51      52      53      54      .��58   
   7  1MaterialDesignThemes.Wpf.Transitions.Transitioner  $��1��6&    �� SelectedIndex$ 0��63   !   AutoApplyTransitionOrigins . .@�5:      � 	 � RowDefinitions	 5<      �� 5=      $
��AUTO �6$   �� 5>      $��* �6$   .+�5A      �� $ 
Horizontal=�6   $��20q�66   .+�5B      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Search=�6.   $��30��6<   $��30��6G   $��	15,0,10,0q�6S   $��Center=�6f   �� 5C      -   5         ��Name$ 	txtSearch��5C      $��Center=�62   $	��250��5D   &   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ SEARCH PATIENT��62   $��15(�6c   �� 5E      -   5         ��Name$ 	btnSearch��5E      $	��100��60   $��Search��6<   $��100,0q�6M    $  MaterialDesignRaisedAccentButton#��[ 6\   5F      '	  !MaterialDesignThemes.Wpf.Snackbar	  5H      -   5         	 Name$ 
MySnackbar��5H   c   $��1��6*   $��Stretch=�67   $
��30,0q�6U    	  MessageQueue 6w   4
  .MaterialDesignThemes.Wpf.MessageQueueExtension
  5J      <  6MaterialDesignThemes.Wpf.Transitions.TransitionerSlide  5L         BackwardWipe 5N      4  .MaterialDesignThemes.Wpf.Transitions.SlideWipe  5O         	Direction$ Right=�6/   .��5R      �  � ColumnDefinitions 5T      �� 5U      $��1* �6+   �� 5V      $��2* �6+   .+�5Y      #  MaterialDesignThemes.Wpf.Card  $��10q�6*   
�������.��5[      �� -   5         ��Name$ 
lvInvoices��5[   #     MaterialDesignCardsListBox#��[ 67   $��15q�6k   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   ��6w   ��  �� Source# [ ��5]      �� 5_   "   .R�5a   &   �  5c   *   �� 5d   .   $
��AUTO �6?   �� 5e   .   $
��AUTO �6?   �� 5f   .   $
��AUTO �6?   �� 5g   .   $
��AUTO �6?   .+�5j   *   �� .+�5l   .   �� $ 
Horizontal=�69   $��5q�6R   .+�5m   2     $
 	Injection=�6J   $��20��6[   $��20��6f   $��Center=�6r   �� 5n   2   $��2��6<   
���   �6F   5o   /   �� 5q   .   $ 
Horizontal=�69   $��5q�6R   .+�5r   2     $
 Money=�6J   $��20��6W   $��20��6b   $��Center=�6n   �� 5s   2   $��2��6<   
���   �6F   5t   /   5v   +   �� 5x   *   $��1��65   .+�5y   .   �� $��
Invoice ID��68   $��Center=�6J   $��14(�6e   $	��3,7q�6s   �� 5z   .   $��Payment Status��68   $��Center=�6N   $��14(�6i   $	��3,6q�6w   5{   +   �� 5}   *   $��2��65   .+�5~   .   �� $��:��68   $��Center=�6A   $��14(�6\   $	��5,6q�6j   �� 5   .   $��:��68   $��Center=�6A   $��14(�6\   $	��5,8q�6j   5�   +   �� 5�   *   $��3��65   .+�5�   .   �� $
��Bold"�6S   $��Center=�6e   $��16(�6�   $	��3,5q�6�   ��68   �� *	InvoiceID+6�   �� 5�   .    ��Name$ 
txtpayment��68   $
��Bold"�6�   $��Center=�6�   $��16(�6  $	��3,7q�6&  ��6L   �� *PaymentStatus+ �� UpdateSourceTrigger$ PropertyChanged=���6�   ��  �� Path$
 Text� �� ElementName$ 
txtpayment�� �� 	Converter# [ 6&  5�   +   ��5�   *   �� 5�   .    �� 
TargetType" �64    �� Triggers 5�   2   P� 5�   6    P� Property �@J�IsMouseOver P� Value .  . �5�   :   ��  �� Property � ��  �� Value
  �����6g   5�   7   P� 5�   6    �@J�IsMouseOver . . �5�   :   ��  � ��  �#CFD8DC6i   5�   7   5�   /   5�   '   5�   #   5�      5�        5�      $��1��6*   $��20,10q�6:   .��5�      � 	 5�      �� 5�   "   $��2* �60   �� 5�   "   $
��1.5* �60   .+�5�        ���#ECEFF1.��5�   "   &   System.Windows.Controls.DataGrid  -   5        !  Name$! dgTreatment��5�   ;   "   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$" * 6+   #   CanUserSortColumns# . $   SelectionMode$$ Extended=�5�   +   %   CanUserAddRows% .  &   CanUserReorderColumns& .  '   AutoGenerateColumns' .  -  'MaterialDesignThemes.Wpf.DataGridAssist(   CellPadding$( 13 8 8 8q�5�   +   )   ColumnHeaderPadding$) 8q�5�   +   $��18(�5�   +   *   
IsReadOnly* . ��6K   �� # [ $ PropertyChanged=�+   ColumnHeaderStyle+ 5�   &   �� 5�   *    & "MaterialDesignDataGridColumnHeader, �� BasedOn#, [ 60   =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6n   .�5�   .   ��  � ��$  18(�6I   �� 5�   .    � ��  �#ECEFF16K   5�   +   -   Columns- 5�   &   1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5�   *   ,  &System.Windows.Controls.DataGridColumn.   Header$. Treatment Name��5�   -   /   	MaxLength$	/ 255��5�   -   1  +System.Windows.Controls.DataGridBoundColumn0   Binding0 5�   -   �� *Nama+5�   -     5�   *   $. Price��5�   -   $	/ 255��5�   -   0 5�   -   �� *Price+5�   -   5�   #   5�      � 5�      $��1��6#   $��
50,20,50,0q�60   $��Right=�6D   .+�5�   "   �  5�   &   �� 5�   *   $
��AUTO �6;   �� 5�   *   $
��AUTO �6;   �� 5�   *   $
��AUTO �6;   �� 5�   *   $
��AUTO �6;   	 5�   &   �� 5�   *   $
��AUTO �68   �� 5�   *   $
��AUTO �68   �� 5�   *   $
��AUTO �68   �� 5�   *   $
��AUTO �68   �� 5�   *   $
��AUTO �68   �� 5�   *   $
��AUTO �68   .+�5�   &   �� $��Nurse Incharge��60   $��0,10,0,5q�6F   �� 5�   &   $��Consultation Fee��60   $	��0,5q�6I   $��1��6V   �� 5�   &   $��Grand Total��60   $	��0,5q�6C   $��2��6P   �� 5�   &   $��Amount Paid��60   $	��0,5q�6C   $��3��6P   �� 5�   &   $��Balance��60   $	��0,5q�6?   $��4��6L   �� 5�   &   $��:��60   $��5,10,0,5q�69   $��1��6K   �� 5�   &   $��:��60   $	��5,5q�69   $��1��6F   $��1��6V   �� 5�   &   $��:��60   $	��5,5q�69   $��1��6F   $��2��6V   �� 5�   &   $��:��60   $	��5,5q�69   $��1��6F   $��3��6V   �� 5�   &   $��:��60   $	��5,5q�69   $��1��6F   $��4��6V   �� 5�   &   -   5        1 ��Name$1 cbbNurse��5�   /   2 �� DisplayMemberPath$2 	FirstName��6z   $��2��6�   $	��0,6q�6�   $��2��6�   $	��200��6  ��6A   �� # [	 3 �� Text3 6�   �� # [ $ StaffFN�6  �� 5�   &   $��RM��60   $��0,7,0,5q�6:   $��2��6K   $��1��6[   �� 5�   &   $��RM��60   $��0,7,0,5q�6:   $��2��6K   $��2��6[   �� 5�   &   $��RM��60   $��0,7,0,5q�6:   $��2��6K   $��3��6[   �� 5�   &   $��RM��60   $��0,7,0,5q�6:   $��2��6K   $��4��6[   �� 5�   &   $��30��60   $��0,7,0,5q�6:   $��Center=�6K   $��3��6h   $��1��6x   �� 5�   &   -   5        $ 	txtAmount��5�   0   $��0,7,0,5q�6�   $��Center=�6�   $��3��6�   $��2��6�   ��6C   �� # [ $ Amount�6�   �� 5�   &   -	   5        $ 
txtPayment��5�   .   $��0,2,0,5q�6C   $	��150��6T   $��Center=�6`   $��3��6�   $��3��6�   .��6�   ��5�   *   �� 5�   .   # [ 66   $
 Paid�6[   $ PropertyChanged=�6g   4 �� ValidationRules4 5�   2   &    Oceana__WPF_.InputValidationRule  5�   6   5   ErrorMessage$"5 Please input a valid amount!��6Q   5�   /   .��5�   8   5�   '   �� 5   &   -
   5        $ 
txtBalance��5   0   $��0,7,0,5q�6�   $��Center=�6�   $��3��6�   $��4��6�   ��6D   �� # [ $ Balance�6�   �� 5  &   -   5        $ btnCheckout��5  @   $��5��5  -   $��3��6:   $��10q�6J     MaterialDesignRaisedButton#��[ 5  -   $��CHECKOUT��5  -   6@   �� 5  &   $��5��6-   $
��EXIT��6:   6   MovePreviousCommand#��Z6 6I   5	  #   5     5     5     	  5     -   5        $ MySnackbarTwo��5  m   $��2��6.   $��Center=�6B   $
��30,0q�6_   $��Bottom=�6�    6�   
  6�   5     5     5     5     5     