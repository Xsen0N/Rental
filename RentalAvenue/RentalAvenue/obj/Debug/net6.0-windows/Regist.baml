   M S B A M L   `   `   `  ����G  CRentalAvenue, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RentalAvenueRentalAvenue  5   	       RentalAvenue.Regist   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:RentalAvenue     5   	     � Title$  Regist��5   	   $	��256��6   $	��300��6%   ��5	      �� 5
   
    �� ImageSource$ img\font.jpg��6    j� Viewbox$ 	0,0,0.5,1�60    �� Opacity$	 0.8Q�6D    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        !   RentalAvenue.CustomCommands   LogIntoProgram   Command# Z 5      6R    � 	Resources 5       �� 
TargetType	 �� Property
 �� Value �� 
TargetType �� CornerRadius ��Name��%�   '��       �� 5   
   " ��6   .�5      �� 	 � ��
 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      $ 5��5      ._�5      �� $ PART_ContentHost��6+   5      5      5      5      5      .��5      � .+�5   
   �  � RowDefinitions 5       �� 5!      $
��Auto �6    �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    �� 5$      .+�5&      ��  
  Regist#���   6   $��Center=�67   $��10q�6T   $��15(�6`   
�������6n   �� 5'      $��1��6    �� Orientation$ Vertical=�6&   $��Center=�6>   .+�5(      ��  	 Login#���  6   $��Center=�6;   $��5q�6V   
�������6a   �� 5)      -   5         ��Name$ 
LogTextBox��5)      $	��200��6/   $��21��6;   
�������
�������6Z   5*      �� 5+      $��2��6   $ Vertical=�6&   $��10q�6=   $��Center=�6I   .+�5,      ��  	 Email#���  6   $��Center=�6;   $��5q�6V   
�������6a   �� 5-      -   5        $ EmailTextBox��5-      $	��200��61   $��22��6=   
�������
�������6\   5.      �� 5/      -   5         ��Name$ Submit��5/   E   $��3��6    
 Submit#���  6"   $��90��6U   $��25��6a   ���#7B68EE
�������$)��#local:CustomCommands.LogIntoProgram��6�    50      ��%^   '��       �� 51      " ��6   .�52      �� 	 �@��CornerRadius$
 5��69   53      54      55      56      57      58      