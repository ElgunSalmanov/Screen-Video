   M S B A M L   `   `   `  ����F  BScreenVideo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ScreenVideoScreenVideo  5   	       ScreenVideo.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ScreenVideo     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � 
���   � � RowDefinitions 5
   
   �� 5      $	��83* �6   �� 5      $
��351* �6   .+�5   
   �� -   5        $
��tbox��5      $	��254��6   $
��Left=�6*   
�������$��	127.0.0.1��6X   $��Center=�6i   $��18(�6�   $��524,10,0,24q�6�   
���   ����	#FFFF0101$��Cambria Math)�6�    � Cursor$ SizeNESW��6�    J� RenderTransformOrigin$ 0.5,0.5&�6  .��6%  z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0Q�6&   T� 5      5      .��5   '   5      �� 5   
   -   5        $��	screenbtn��5      $	��170��6"   $
��Left=�6.   $��
23,10,0,24q�6I   $��18(�6]   
�������
���������5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#   � 5      $ 	#FFFB0000��6#    � Offset$ 1Q�65   5      .��5   !   Screen5      �� 5    
   -   5        $��image��5       $��1��6   $��noimage.jpg��6*   $��	0,10,1,10q�6?   5!      5"      