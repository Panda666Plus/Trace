   M S B A M L   `   `   `  ����@  <Trace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Trace.Views.production_recordsTrace.Views.production_records  5   	   7 clr-namespace:Trace.Common.validTrace.Common.valid  5   	   +    %Trace.Views.production_records.ForFat   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:Trace.Views.production_records     5   	   2valid clr-namespace:Trace.Common.valid     5   	     � Title$  施药��5	   	   $	��310��6   $��758.161��6!    � WindowStyle$
 None=�61    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6^    � 	Resources 5
       �� 
TargetType   ComboxStyleBtn �� Property �� Value ��Name	 F�Name
 J� RenderTransformOrigin �� Stretch �� Angle �� Triggers P� Property P� Value �� 
TargetName  ArrowDownPathButton �� 
TargetType  VerticalScrollBarPageButton  ScrollBarThumb �� CornerRadius  ArrowUpPathButton  ArrowLeftPathButton ! HorizontalScrollBarPageButton  ArrowRightPathButton  ScrollBarStyle �Name J� SnapsToDevicePixels � RowDefinitions �� LineUpCommand J� IsMouseOver ]�Name ]� DecreaseRepeatButton �� PageUpCommand ]� IncreaseRepeatButton �� PageDownCommand ]� Thumb �� LineDownCommand �� Triggers  � ColumnDefinitions! �� LineLeftCommand" �� PageLeftCommand# �� PageRightCommand$ �� LineRightCommand 	 ScrollViewerStyle% ��Name& ��Name' �� CanContentScroll( ��Name4  .System.Windows.Automation.AutomationProperties)   AutomationId* � Cursor+ �� ScrollableHeight, � Maximum- � Minimum*. �� #ComputedVerticalScrollBarVisibility/ �� ViewportHeight0 �� ViewportSize1 � Value2 �� Mode3 �� RelativeSource4 �� ScrollableWidth,5 �� %ComputedHorizontalScrollBarVisibility6 �� ViewportWidth7 �� Orientation 
 ComboBoxStyle8 �� 
IsReadOnly9 �� 
IsReadOnly: �� Text; �� 	ClickMode< d� 	IsChecked= �Name> �� IsDropDownOpen? � AllowsTransparency@ �� MaxDropDownHeightA � ActualWidthB J� Effect3  -System.Windows.Media.Effects.DropShadowEffectC   ColorD   
BlurRadiusE   ShadowDepthF   OpacityG K� IsItemsHost-  'System.Windows.Input.KeyboardNavigationH   DirectionalNavigation  styleSubmit 
 style3  TextBoxStyleI �� ElementNameJ �� Path  TextBlockStyle��%�/  &	        &	 �    &	 p    &	 �    &	 �    &	 �    &	 ?    &	 �    &	 Z    7  7  7  7  7  7  &		 �    &	
 �    7   &	 �#    &	 (    &	 �,    &	 s.    �� 5   
   " d�6   .�5      ��  � �� 5      �� 5      .R�5      �� $
 Back��6!   ���#F7FDF7$��1q�6D   
������ ._�5      F� $	 PathFill��6#   ���#59CA4F$��8��6D   $��6��6N   $��0��6Y   "����@KL     р�� ��� �    ��� 	$
 0.5,0.5&�6�   $
 Fill=�6�   z�5   "   V� 5   &   .~�5   *   �� �� 5   *   �� 5   *   $	 180Q�6:   T� 5   *   5   '   5      5       5      P� 5       �@J�IsMouseOver . . �5   "   �� $ PathFill��6)    � ��
 �����6O   �� 5   "   $
 Back��6)    � �� �#59CA4F6Q   �� 5    "   $
 Back��6)    � �� �#59CA4F6R   5!      5#      5%      5&      �� 5(   
   " ��6,   .�5)      ��  � �� 5*      �� 5+      " ��6&   .R�5,      � 
������ .+�5-      F� $	 PathFill��6#   ���#868999$��13��6D   $��8��6O   $��0��6Z   ,�������  @    р�� ��� ��%d?uV���� 	$
 0.500000001045782,0.5&�6�   $
 Fill=�6�   z�5.   "   V� 5/   &   .~�50   *   �� �� 51   *   �� 52   *   $	 180Q�6:   T� 53   *   54   '   56      57       58      P� 59       �@J�IsMouseOver . . �5:   "   �� $ PathFill��69    � �� �#1C97EA6O   5;      P� 5<       � �� . . �5=   "   �� $ PathFill��69    � �� �	#FF4D84AE6O   5>      5@      5B      5C      �� 5E   
   " ��64   .�5F      ��  �@�OverridesDefaultStyle . 66   �� 5G       � ��
 ���� 6+   �� 5H       � |� .  6*   �� 5I       � �� .  6*   �� 5J       � �� 5K      �� 5L      " ��6&   .R�5M      �� #��z��6$   #��z��6H   #��z��6j   5N      5P      5Q      �� 5S   
   " n�6'   .�5T      ��  �@�OverridesDefaultStyle . 66   �� 5U       � �� .  6*   �� 5V       � �� 5W      �� 5X      " n�6&   .R�5Y      �� $ border��6!   $ 3��61   ���#ACACAC$��0q�6W    5Z      P� 5[       �@J�IsMouseOver . . �5\   "   �� $ border��6?    � �� �#8888886S   5]      P� 5^       �@n�
IsDragging . . �5_   "   �� $ border��6?    � �� �#8888886S   5`      5b      5d      5e      �� 5h   
   " ��6*   .�5i      ��  � �� 5j      �� 5k      " ��6&   .R�5l      � 
������ .+�5m      F� $	 PathFill��6#   ���#868999$��13��6D   $��8��6O   $��Center=�6Z   $��Center=�6u   $��0��6�   ,�������  @    р�� ��� ��%d?uV���� 	$
 0.500000001045782,0.5&�6�   $
 Fill=�6  z�5n   "   V� 5o   &   .~�5p   *   �� �� 5q   *   �� 5r   *   $ 0Q�6:   T� 5s   *   5t   '   5v      5w       5x      P� 5y       �@J�IsMouseOver . . �5z   "   �� $ PathFill��69    � �� �#1C97EA6O   5{      P� 5|       � �� . . �5}   "   �� $ PathFill��69    � �� �	#FF4D84AE6O   5~      5�      5�      5�      �� 5�   
   " ��6,   .�5�      ��  � �� 5�      �� 5�      " ��6&   .R�5�      � 
������ .+�5�      F� $	 PathFill��6#   ���#868999$��13��6D   $��8��6O   $��0��6Z   ,�������  @    р�� ��� ��%d?uV���� 	$
 0.500000001045782,0.5&�6�   $
 Fill=�6�   z�5�   "   V� 5�   &   .~�5�   *   �� �� 5�   *   �� 5�   *   $	 -90Q�6:   T� 5�   *   5�   '   5�      5�       5�      P� 5�       �@J�IsMouseOver . . �5�   "   �� $ PathFill��69    � �� �#1C97EA6O   5�      P� 5�       � �� . . �5�   "   �� $ PathFill��69    � �� �	#FF4D84AE6O   5�      5�      5�      5�      �� 5�   
   " ��66   .�5�      ��  �@�OverridesDefaultStyle . 66   �� 5�       � ��
 ���� 6+   �� 5�       � |� .  6*   �� 5�       � �� .  6*   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� #��z��6$   #��z��6H   #��z��6j   5�      5�      5�      �� 5�   
   " ��6-   .�5�      ��  � �� 5�      �� 5�      " ��6&   .R�5�      � 
������ .+�5�      F� $	 PathFill��6#   ���#868999$��13��6D   $��8��6O   $��Center=�6Z   $��Center=�6u   $��0��6�   ,�������  @    р�� ��� ��%d?uV���� 	$
 0.500000001045782,0.5&�6�   $
 Fill=�6  z�5�   "   V� 5�   &   .~�5�   *   �� �� 5�   *   �� 5�   *   $ 90Q�6:   T� 5�   *   5�   '   5�      5�       5�      P� 5�       �@J�IsMouseOver . . �5�   "   �� $ PathFill��69    � �� �#1C97EA6O   5�      P� 5�       � �� . . �5�   "   �� $ PathFill��69    � �� �	#FF4D84AE6O   5�      5�      5�      5�      �� 5�   
   " ��6'   .�5�      ��  �@��IsPressAndHoldEnabled .  6=   �� 5�       �@��IsFlicksEnabled .  67   �� 5�       � ��# � ��6+   �� 5�       � ��# � r�6&   �� 5�       � ��# � r�6)   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      � $ Bg��6   #��z��6+    .  5�      �� 5�   "   #��� q�60   �� 5�   "   $��0.00001* �60   �� 5�   "   #��� q�60   .+�5�      �� #���  6+   #��Z 6Y   #{�z 6�   ]� 5�      $ 
PART_Track��6$   ��. #{�z 6S   $��1��6}    5�   "   �� 5�   &   #��Z 63   8��  6`    5�   "   �� 5�   &   #��Z 63   8�� 6b    5�   "   n� 5�   &   8�� $��3,0,3,0q�6T   5�      �� 5�      #��Z 6+   #{�z 6Z   $��2��6�   #���  6�   5�      5�      5�       5�      P� 5�       �@��Orientation$ 
Horizontal=�61   . �5�      ��  � ��$
 Auto��6.   �� 5�       � ��$ 0��61   �� 5�       � ��# � ��6/   �� 5�       � ��# � ��62   �� 5�       � �� 5�      �� 5�      " ��6.   .R�5�   "   � $ Bg��6'   #��z��63    .   5�   &   �� 5�   *   #��� ��6;   �� 5   *   $��0.00001* �6;   �� 5  *   #��� ��6;   .+�5  &   �� #��Z! 63   #{�z 6b   #���  6�   ]� 5  &   $ 
PART_Track��6,   $��1��6@   #{�z 6P    5  *   �� 5  .   #��Z" 6;   8�� 6j    5  *   �� 5	  .   #��Z# 6;   8�� 6k    5  *   n� 5  .   8�� $��0,3,0,3q�6\   5  '   �� 5  &   $��2��63   #��Z$ 6C   #{�z 6s   #���  6�   5  #   5     5     5     5     �� 5  
   " ��6   .�5     ��  � �� 5     �� 5     " ��6&   .R�5     � $
 Grid��6   #��z��6-     5     �� 5  "   $��* �63   �� 5   "   $
��Auto �63    5"     �� 5#  "   $��* �60   �� 5$  "   $
��Auto �60   .+�5'     �� $% Corner��6(   $��1��69   $��1��6F   #��� ��6V   �� 5)     $!& PART_ScrollContentPresenter��65   $��0��6Z   $��0��6g   #��z��6w   #' z��6�   #��z��6�   #��z��6  �� 5+     $( PART_VerticalScrollBar��6(   $��0��6J   $��1��6W   $) VerticalScrollBar��6g   $* Arrow��6�   #, z+ 6�   $- 0Q�6�   #y�z. 6�   #0 z/ 6�  #���  6�  1 6,  �� *VerticalOffset+$2 OneWay=�3 �� *TemplatedParent+6�  �� 5-     $( PART_HorizontalScrollBar��6(   $��1��6J   $��0��6W   $) HorizontalScrollBar��6g   $* Arrow��6�   #, z4 6�   $- 0Q�6�   #y�z5 6�   #0 z6 6�  #���  6�  $7 
Horizontal=�6�  1 6,  �� *HorizontalOffset+$2 OneWay=�3 �� *TemplatedParent+6�  5.      5/     P� 50      � ��$ Disabled=�6O   52     54     56     �� 59  
   " ��6   .�5:     ��  � �� 5;     �� 5=     " ��6   .�5>     ��  � ��$ 22��66   �� 5?      � ��$ 60��65   �� 5@      � �� 5A     �� 5B  "   " ��62   .R�5C  &   �� $
 Back��6-   
������ $��0,0,0,0q�6U   ���#81D779._�5D  *   �� $��Center=�6\   $
��Left=�6w   $��5,0,0,0q�6�   ��6;   �� *Source+6�   5E  '    5F  &   P� 5G  *    �@J�IsMouseOver . . �5H  .   �� $
 Back��65    � ��
 �����6]   5I  +   P� 5J  *    �@��IsHighlighted . . �5K  .   �� $
 Back��65    � ��
 �����6]   5L  +   5N  #   5P     5Q     5S     �� 5T      � �� 5U     �� 5V     " ��6&   .R�5W     � ���#F7FDF7  5X     �� 5Y  "   $
��0.7* �63   �� 5Z  "   $
��0.3* �63   $��30��6@   .+�5\     �� $��0��6'   #9 z8 67   #��z: 6a   �� 5]     $��0��6&   $��1,1,0,1q�66   ���#81D779$ 1,0,0,1��6f   �� 5^     $��1��6%   $��0,1,1,1q�65   ���#81D779$ 0,1,1,0��6e   ._�5_  "   d� 8��  $; Press=�6�   < 6W   �� *IsDropDownOpen+$2 TwoWay=�3 �� *TemplatedParent+6�   5`     � 5a     $= Popup��6a   #��z> 6$   $��Bottom=�6N   |�.  ? . $��Slide=�6�   .��5b  "   �� $ DropDown��6�   $ 1��6)   #��z@ 6:   #��zA 6j    . B 5c  &     5d  *   $C Black��6;   $D 2Q�6I   $E 0Q�6X   $	F 0.5Q�6h   ._�5f  &   �� $��4,6,4,6q�63   #��� 	 6D   #��z@ 6p    . $
��Auto=�6�   $
��Auto=�6�   ��. .��5h  *   �� G . $H 	Contained=�6H   
�������6}   5i  '   5j  #   5k     5l     5m     5o     5p     �� 5q  
   " ��6   .�5r     ��  �@�OverridesDefaultStyle . 66   �� 5s      � |� .  6*   �� 5t      �@�Cursor$
 Hand��6'   �� 5u      � �� �#0006+   �� 5v      � ��$ 14(�6)   �� 5w      � �� �#f4f4f46+   �� 5x      � �� �#9996,   �� 5y      � ��$ 1q�60   �� 5z      � ��$ Center=�6;   �� 5{      � ��$ Center=�69   �� 5|      � ��$ 25��6'   �� 5}      � ��$ 60��6&   �� 5~      � �� 5     �� 5�     " ��6&   .R�5�     �� $ Chrome��6!   $��0q�61   #��z��6E   #��z��6q    . ._�5�     �� #��z��6/   #��z��6r   ��. # z 5�  <   #��z��5�  !   5�      5�     P� 5�      � {� .  . �5�  "   ��  � �� �#ADADAD6?   5�     P� 5�      �@J�IsMouseOver . . �5�  "   �� $ Chrome��6)    � �� �#00FF006S   �� 5�  "    � ��
 �����6?   5�     5�     5�      5�     P� 5�      �@J�IsMouseOver . . �5�     ��  � �� �	#FF23AA3663   �� 5�      � �� �#fff63   5�     5�     �� 5�  
   " ��6   .�5�     ��  �@�OverridesDefaultStyle . 66   �� 5�      � |� .  6*   �� 5�      �@�Cursor$
 Hand��6'   �� 5�      � �� �#0006+   �� 5�      � ��$ 14(�6)   �� 5�      � �� �	#FF5AD36B6+   �� 5�      � �� �#9996,   �� 5�      � ��$ 1q�60   �� 5�      � ��$ Center=�6;   �� 5�      � ��$ Center=�69   �� 5�      � ��$ 25��6'   �� 5�      � ��$ 60��6&   �� 5�      � �� 5�     �� 5�     " ��6&   .R�5�     �� $ Chrome��6!   $��0q�61   #��z��6E   #��z��6q    . ._�5�     �� #��z��6/   #��z��6r   ��. # z 5�  <   #��z��5�  !   5�      5�     P� 5�      � {� .  . �5�  "   ��  � �� �#ADADAD6?   5�     P� 5�      �@J�IsMouseOver . . �5�  "   �� $ Chrome��6)    � �� �#FF00006S   �� 5�  "    � ��
 �����6?   5�     5�     5�      5�     P� 5�      �@J�IsMouseOver . . �5�     ��  � �� �#99963   �� 5�      � �� �#fff63   5�     5�     �� 5�  
   " ��6%   .�5�     -   5         5�     P� 5�      �@=�HasError . . �5�     ��  �@=�ErrorTemplate 5�     �� 5�     .R�5�  "   ]� ��. .+�5�  &   �� $��Bottom=�60   
���  ��$��13(�6Y   ��5�  !   �� $I 	errorHint��$8J 2AdornedElement.(Validation.Errors)[0].ErrorContent�5�  '   �� 5�  &   
���  ��$��1q�6?   ._�5�  *   �� $��	errorHint��6D   5�  '   5�  #   5�     5�     5�     5�     �� 5�  
   " ��6'   .�5�     ��  � ��$ 20(�6)   �� 5�      � ��$
 Left=�64   �� 5�      � ��$ Center=�62   5�     5�     .��5�     � -   5        $��0,0,2,1q�5�     .+�5�  
   �� -   5        K ��Name$K label��5�     $��施药记录操作��6   $
��Left=�60   $��31��6K   $��12,5,0,0q�6W   $��15(�6i   $	��Top=�6w   $	��102��6�   $
��Bold"�6�   �� 5�  
   
�������$��0,1,0,0q�6*   $
��Left=�6D   $��3��6_   $	��Top=�6j   $	��757��6�   $��	1,36,-2,0q�6�   $
 0.5,0.5&�6�   z�5�     V� 5�     .~�5�     �� L �� ScaleY$L -1Q�6%   �� 5�     M �� AngleY$M -0.002Q�6$   �� 5�     T� 5�     N T� Y$N -0.016Q�6)   5�     5�     �� 5�  
   -   5        $K label1��5�     $��动作类型：��6    $
��Left=�60   $��30��6K   $��	39,56,0,0q�6W   $	��Top=�6j   $��66��6�   $
 -0.389,-1.444&�6�   �� 5�  
   -   5        O ��Name$O 
actionType��5�     P �� SelectedIndex$P 0��6'   Q �� SelectedValuePath$Q CODE_VAL��69   R �� DisplayMemberPath$R 	CODE_NAME��6V   #��[
 6t   $
��Left=�6�   $��
113,56,0,0q�6�   $	��Top=�6�   $��30��6�   $	��209��6�   �� 5�  
   -   5        $K label3��5�     $��产品名称：��6    $
��Left=�60   $��30��6K   $��
39,121,0,0q�6W   $	��Top=�6k   $��67��6�   �� 5�  
   -   5        $O produceName��5�     $Q 
PRODUCE_ID��6(   $R PRODUCE_NAME��6G   #��[
 6h   $
��Left=�6�   $��113,119,0,0q�6�   $	��Top=�6�   $��30��6�   $	��209��6�   �� 5�  
   -   5        $K label6��5�     $��	备注：��6    $
��Left=�6.   $��26��6I   $��
60,182,0,0q�6U   $	��Top=�6i   $��45��6�   �� 5�  
   -	   5        S ��Name$S remark��5�     $
��Left=�6"   $��52��6=   $��113,170,0,0q�6I   T �� TextWrapping$
T Wrap=�6^   $	��Top=�6r   $	��208��6�   �� 5�  
   -
   5        $K label5��5�     $��计量单位：��6    $
��Left=�60   $��29��6K   $��419,119,0,0q�6W   $	��Top=�6l   $��67��6�   �� 5�  
   -   5        $S 
amountUnit��5�     $
��Left=�6&   $��494,119,0,0q�6A   $
T Wrap=�6V   $	��Top=�6j   $��30��6�   $	��209��6�   �� 5�  
   -   5        $K label22��5�     $��       计量：��6!   $
��Left=�66   $��
420,56,0,0q�6Q   $	��Top=�6e   $��66��6}   �� 5�  
   -   5        $S amount��5�     #��[ 6"   $
��Left=�6H   $��
494,57,0,0q�6c   $
T Wrap=�6w   $	��Top=�6�   $��30��6�   $	��208��6�   .��6�   ��5�     �� 5�     $J Number�6   U �� UpdateSourceTrigger$U 	LostFocus=�6(   V �� ValidationRulesV 5�     -  'Trace.Common.valid.NumberValidationRule  5�     5      .��5     5     �� 5  
   -   5        $��txtAddressHint��5  ;   $��24��6   $
��Left=�6    
���  ��$��14(�6b   $	��Top=�6p   $	��208��6�   $��
494,88,0,0q�6�   �� 5  
   -   5        $S hidProId��5     $y�Hidden=�6$   �� 5  
   
�������$��0,1,0,0q�6*   $
��Left=�6D   $��4��6_   $	��Top=�6j   $	��758��6�   $��
0,229,-2,0q�6�   $
 0.5,0.5&�6�   z�5     V� 5     .~�5	     �� $L -1Q�6%   �� 5
     �� 5     T� 5     5     5     �� 5  
   -   5        W ��Name$W 	btnSubmit��5     $��提 交��6$   #��[ 62   $
��Left=�6X   $��686,247,0,0q�6s   $	��Top=�6�   $��0q�6�   $��14(�6�   $��31��6�   $��54��6�   ���	#FFF5EFEF$
��Bold"�6  ��5     �� 5     X �� EndPoint$	X 0,1&�6&   Y �� 
StartPoint$	Y 0,0&�65   .��5     � Z � Color$Z 	#FFF3F3F3��6#   [ � Offset$[ 0.997Q�65   � 5     $Z 	#FFEBEBEB��6#   $[ 1Q�65   � 5     $Z 	#FFDDDDDD��6#   $[ 1Q�65   � 5     $Z 	#FF35BF3B��6#   $[ 1Q�65   � 5     $Z 	#FF219126��6#   $[ 0.952Q�65   5     5     �� 5  
   -   5        $W 	btnCancel��5     $��取 消��6$   #��[ 62   $
��Left=�6R   $��629,247,0,0q�6m   $	��Top=�6�   $��0q�6�   $��14(�6�   $��31��6�   $��52��6�   $
 
0.36,0.516&�6�   $
��Bold"�6�   ��5     �� 5     $	X 0,1&�6&   $	Y 0,0&�65   .��5     � $Z 	#FFF3F3F3��6#   $[ 0.997Q�65   � 5     $Z 	#FFEBEBEB��6#   $[ 1Q�65   � 5      $Z 	#FFDDDDDD��6#   $[ 1Q�65   � 5!     $Z 	#FFCDCDCD��6#   $[ 1Q�65   5"     5$     5&     5'     