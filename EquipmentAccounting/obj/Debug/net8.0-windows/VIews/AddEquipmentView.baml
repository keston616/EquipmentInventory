   M S B A M L   `   `   `  ����N  JEquipmentAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:EquipmentAccounting.VIewsEquipmentAccounting.VIews  5      0    *EquipmentAccounting.VIews.AddEquipmentView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:EquipmentAccounting.VIews     5        � 	Resources  5	       �� 
TargetType �� Property �� Value   HeaderStyle��%`  '��       '�� q     '�� �     &	  t    �� 5
   
   " ��6   .�5      ��  � ��$ 0 0 0 15q�6'   �� 5       � ��$ 5q�6(   5      �� 5   
   " ��6   .�5      ��  � ��$ 0 0 0 20q�6'   �� 5       � ��$ 5q�6(   5      �� 5   
   " ��6   .�5      ��  � ��$
 10 5q�6(   �� 5       � ��$ 5q�6'   �� 5       � ��$	 100��6&   5      �� 5   
   " ��6$   .�5      ��  � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 0 0 0 10q�6'   �� 5       � �� �	#FF673AB76+   5      5       .��5"      �� $��10q�6   
����������	#FFD0D0D0$��1q�6D    �� Padding$ 20q�6X   ._�5#   
   �  � ColumnDefinitions 5$      �� 5%      $	��200 �6#   �� 5&       � RowDefinitions 5(      �� 5)      $
��Auto �6    �� 5*      $
��Auto �6    �� 5+      $
��Auto �6    �� 5,      $��* �6    �� 5-      $
��Auto �6    .+�51      �� $��0��6   $/��)Добавить оборудование��6%   #��[  6B   �� 53      $0��*Название оборудования:��6   $��0��66   $��1��6F   $	��200��6S   $��0,3,0,0q�6_   �� 54      $��1��6   $��1��6&   $��Stretch=�63   
 � Tag$ Наименование��55   T   ��6   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�6T   �� 59      $&�� Тип оборудования:��6   $��0��61   $��2��6A   $	��200��6N   $��0,3,0,0q�6Z   �� 5:      $��2��6   $��1��5;      	 �� DisplayMemberPath$
	 Name��5>      
 �� SelectedValuePath$
 Id��5?      $% Тип оборудования��5@      ��5<      �� *EquipmentTypes+ �� SelectedValue 5=      �� *TypeId+5@      �� 5C      $��4��6   $��1��6&    �� Orientation$ 
Horizontal=�66   $��Right=�6O   .+�5D      �� $��Отмена��6   ���	#FFE0E0E0
���   ���5E      �� *CancelCommand+5G      �� 5I      $��Сохранить��6   ���	#FF673AB7
���������5J      �� *SaveCommand+5L      5M      5N      5O      5P      