   M S B A M L   `   `   `  ����  SalonManager,    &SalonManager.Views.ComsumeDetailWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ 客戶消費紀錄資料��5   	   $��626.809��6   $��1043.83��6+   .��5      � -   5        $��DataGrid��5      .+�5   
   ��  �� Orientation$ Vertical=�6   $	��Top=�6,   $
��Left=�6D   .+�5      �� -   5        $��CustomerName��5      $	��XXX��6-    �� Padding$	 5,5q�68   
����  �$��18(�6X   �� 5	      -   5         ��Name$ ScalpTypeString��5	      $	 5,5q�61   �� 6@   $��18(�6D   $	�XXX��6R   6`   �� 5
      $��消費紀錄清單��6   $	 5,5q�6&   
���  ��$��18(�6E   &   System.Windows.Controls.DataGrid  5      -   5        $��ComsumeGrid��5      $
��1019��6*   $	��426��67   $   HorizontalScrollBarVisibility$
 Auto=�6D   "   VerticalScrollBarVisibility$ Visible=�6i   $��18(�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly . 	   Header$	 日期��5   )   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 1* 65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   )   �� *
DateString+5   5     5       . $	 服務員工��5   )      
Foreground
 ��  �$
 1* 6I    5   )   �� *EmployeeName+5   I   4  .System.Windows.Controls.DataGridCheckBoxColumn  5       . $	 指定��5   )   $
 0.33* 65    5   -   �� *	IsSpecify+5   5     5       . $	 消費物品��5   )   $
 1* 67    5   )   �� *ConsumerGoods+5   7     5       . $	 服務內容��5   )   $
 1* 67    5   )   �� *	Service+5   7     5       . $	 預付金扣抵��5   )   
 �  ��$
 1* 6I    5   )   �� *	Payment+5   I     5       . $	 	總金額��5!   )   
 �  ��$
 1* 6G    5   )   �� *Cost+5!   G   5#      5$      �� 5%   
   $ 
Horizontal=�6   $��Center=�6.   $��Bottom=�6K   .+�5&      �� -   5        $��PrintButton��5&   .   $��列印��6   $��10q�6"   
�������
��� � �$��18(�6�   $
��Auto��6�   �� 5'      -   5        $��CloseButton��5'   .   $��離開��6   $��10q�6"   
�������
���  ��$��18(�6   $
��Auto��6�   5(      5)      5*      