   M S B A M L   `   `   `  ����N  JEquipmentAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:EquipmentAccounting.VIewsEquipmentAccounting.VIews  5      1    +EquipmentAccounting.VIews.ListEquipmentView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:EquipmentAccounting.VIews     5        � 	Resources  5	       �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%s  '��       '      '  �    �� 5
   
   " ��6   .�5      ��  � ��$
 10 5q�6(   �� 5       � ��$ 5q�6'   �� 5       � �� �	#FF673AB76+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��$ SemiBold"�6+   5      �� 5   
   "  6   .�5      ��  � ��$ 10q�6'   �� 5       � ��
 �����6+   �� 5       � �� �	#FFD0D0D06,   �� 5       � ��$ 1q�60   �� 5       �@ RowBackground
 �����6.   �� 5        �@ AlternatingRowBackground �	#FFF5F5F569   �� 5       �@ GridLinesVisibility$
 None=�64   �� 5       �@ HeadersVisibility$ Column=�62   �� 5       �@ AutoGenerateColumns$ False��64   �� 5       �@ 
IsReadOnly$
 True��6+   �� 5       �@ SelectionMode$ Single=�6.   �� 5       �@ SelectionUnit$ FullRow=�6.   5       �� 5"   
   "  6   .�5#      ��  � �� �	#FF673AB76+   �� 5$       � ��
 �����6+   �� 5%       � ��$
 10 5q�6(   �� 5&       � ��$ SemiBold"�6+   5'      5(      .��5*      �  � RowDefinitions 5+   
   �� 5,      $
��Auto �6   �� 5-      $��* �6   .+�51   
   �� $��0��6   ���	#FF673AB7 �� Padding$ 10q�65   ._�52      ��  �� Orientation$ 
Horizontal=�6   .+�53      �� $'��!Учет оборудования��6   
�������$��18(�55      $
��Bold"�56      $��Center=�57      $
��10,0q�58      �� 5:      $ 
Horizontal=�6   $��Right=�66   $��20,0,0,0q�6R   .+�5;      �� $��Добавить��6   $	��100��5=      ��5<      �� *
AddCommand+5=      �� 5?      $ ��Редактировать��6   $	��120��5A      ��5@      �� *EditCommand+{�5B      �� *SelectedEquipment+   NullToBoolConverter �� 	Converter# [  �� 5D      $��Удалить��6   $	��100��5F      ��5E      �� *DeleteCommand+{�5G      �� *SelectedEquipment+# [  5H      5I      5J      �� 5M   
   $��1��6   $��10q�6   
����������	#FFD0D0D0$��1q�6U   ._�5N        ��6   �� *EquipmentList+ �� SelectedItem 5O      �� *SelectedEquipment+	   Columns	 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6L     5R      $
 Наименование��6)   $ * 6X    6?   �� *Name+6X     5S      $
 Тип��6)   $
 Auto 6S    66   �� *
TypeName+6S     5T      $
 Статус��6)   $
 Auto 6X    69   �� *
StatusName+6X   5V      5W      5X      5Y      