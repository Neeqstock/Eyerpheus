   M S B A M L   `   `   `  ����H  DEyeXFramework, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullL6clr-namespace:EyeXFramework.Wpf;assembly=EyeXFrameworkEyeXFramework.Wpf  5   	    GazeAwareElements"   GazeAwareElements.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   GeyeX6clr-namespace:EyeXFramework.Wpf;assembly=EyeXFramework     5   	   -   5          � Title$  
MainWindow��5
   	   $	��700��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65    � 	Resources 5         EyeXGazeAwareElement �� 
TargetType    EyeXFramework.Wpf.Behavior �� Property �� Value  EyeXGazeAwarePanel �� BasedOn �� Triggers P� Property	 P� Value  EyeXGazeAwareButton  EyeXGazeAwareText  EyeXGazeAwareInstruction
 �� Binding �� Value N� EnterActions �� TargetProperty W� From	 W� To g� Duration g� FillBehavior �� KeyTime �� Value N� ExitActions��%c  &	        &	 �     7   &	 7    7   &	 �    7   &	 �    �� 52   
   " �6-   .�53      ��  �@ 	GazeAware . 68   �� 54       �@ GazeAwareDelay$	 250��6=   55      �� 5?   
   8   " K�6[   .�5@      ��  � ��
 ��p��6+    5A      P� 5B       �@ HasGaze	 . . �5C      ��  � ��
 �� ��63   5D      5F      �� 5H   
   8   " ��6\   .�5I      ��  � ��
 ��İ�6+    5J      P� 5K       �@ HasGaze	 . . �5L      ��  � ��
 ��� �63   5M      5O      �� 5Q   
   8   " ��6Z   .�5R      ��  � ��
 �iii�6+    5S      P� 5T       �@ HasGaze	 . . �5U      ��  � ��
 �   �63   5V      5X      �� 5_   
   " ��61   .�5`      ��  �@ 	GazeAware . 68   �� 5h       �@ GazeAwareDelay$	 450��6=   -   5        �� 5l       � ��$ 24(�6)   �� 5m       � ��$" Look here for instruction...��6%    5p      �� 5�      
 6   �� *ShowInstruction+ True6B    5�      �� 5�      .��5�      �� .��5�   "   W� $ FontSize�62   $ 24X�5�   2   $ 18X�6<   $ 0:0:0.3D�6D   �� 5�   "   $
 Text�6@   $ 0:0:1D�5�   @   $ HoldEnd=�6Q   .�5�   &   a� $ 0:0:0��6=     Look here for instruction...6O   a� 5�   &   $ 0:0:0.3��6=   � �Instruction: The visual elements above respond to your eye-gaze. First, move away the mouse cursor. Now, look at one of the colored surfaces or the 'Hello!', and after a pre-defined delay they will change color from a dim to a clear color. As long as the eye-gaze falls within a child element its parent element will be considered looked at as well. Open MainWindow.xaml to see how it is done. (C)lose instruction. (Q)uit application.6O   5�   #   5�      5�       5�      �� 5�      .��5�      �� .��5�   "   W� $ FontSize�62   $ 18X�5�   2   $ 24X�6<   $ 0:0:0.0D�6D   �� 5�   "   $
 Text�6@   $ 0:0:0.3D�5�   <   $ HoldEnd=�6O   .�5�   &   a� $ 0:0:0��6b     Look here for instruction...6=   6b   5�   #   5�      5�      5�      5�      5�      .��5�      �  � RowDefinitions 5�   
   �� 5�      $	��10* �6   �� 5�      $	��60* �6   �� 5�      $	��10* �6   �� 5�      $	��30* �6    � ColumnDefinitions 5�   
   �� 5�      $	��10* �6   �� 5�      $	��80* �6   �� 5�      $	��10* �6   .+�5�   
   �� $��1��6   $��1��5�      #��[ 5�      .+�5�      �� $��70q�6   $��0q�5�      #��[ 5�      .��5�      �� $��70q�6   $��72(�5�      $
��Bold"�5�      #��[ 5�      Hello!5�      5�      5�      �� 5�   
   $��3��6   $��1��5�      $��Stretch=�5�      $	��150��5�      $	��100��5�      ��5�      Z� ._�5�      �� $��3��6   $��1��5�      $��WrapWithOverflow=�5�      $	��Top=�5�       �� Padding$ 0 0 0 10q�5�      
������ #��[ 5�      5�      5�      5�      5�      