   M S B A M L   `   `   `  ����@  <Trace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TraceTrace  5   	   9!clr-namespace:Trace.MyContrlClassTrace.MyContrlClass  5   	       Trace.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Trace     5   	   ;MyContrlClass!clr-namespace:Trace.MyContrlClass     5   	   -   5          �Name$  Login1��5   A    � Icon$. (/Trace;component/Res_/images/favicon.ico��6h   $	��614��5      $
��1030��6'   $��8q�65    � WindowStartupLocation$ CenterScreen=�6I    � AllowsTransparency .  � WindowStyle$
 None=�6�    J� 	AllowDrop .  � Title$ 登录��6�    � 	Resources 5	         LoginButtonStyle �� 
TargetType	 �� Property
 �� Value �� 
TargetType �� Orientation �� Triggers P� Property P� Value �� 
TargetName��%R  &	        �� 5
   
   " ��6)   .�5      �� 	 � ��
 5      �� 5      " ��6&   .R�5      �� $ 
Horizontal=�6%   .+�5      �� $��	ImgBtnBg3��6$   $��72��65   $��72��6@   $+��%/Trace;component/Res_/Images/lg02.png��6L   6}   5       5      P� 5       �@J�IsMouseOver . . �5   "   �� $ 	ImgBtnBg3��6k   	 � ��$-
 '/Trace;component/Res_/Images/lg02_1.png��6;   6k   5      P� 5       � �� . . �5   "   �� $ 	ImgBtnBg3��6i   	 � ��$+
 %/Trace;component/Res_/Images/lg02.png��6;   6i   5      5      5      5      5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5   
      
BlurRadius$ 13Q�6      Color$ 	#FF7F9DB9��6+      ShadowDepth$ 0Q�6=   ��5!      �� 5"   
    �� ImageSource$+ %/Trace;component/Res_/images/lg03.png��6    j� TileMode$
 Tile=�6I   .��5$      �� ��5%   
   �� 5&      .+�5(   
   �� -   5         ��Name$ Login3��5(      $	��394��6!   $	��184��6-    �� Left$	 328��6:   
 �� Top$	 414��6L   $y�Hidden=�6]   .+�5)      �� -   5         ��Name$ LoginLoadingLabel��5)      $��登录中，请稍候...��6/   $��26��6D   $	 136��6P   $ 82��6b   $��96��6r   ���	#FF8B88886�   5*      �� 5+   
   -   5        $ MsgTip��5+      $
��1014��6!   $��26��6.   $	 572��6:   $y�Hidden=�6K   ���	#FFF1F1A0$��Center=�6v   $��Center=�6�   .+�5,      �� -   5        $ MsgTipLabel��5,      $��提示��6)   $��26��66   ���	#FFFB3838$��Center=�6Y   $��Center=�6v   $��Center=�6�   $��Center=�6�   $	 498��6�   5-      �� 5.   
   -   5        $ Login2��5.      $	��394��6!   $	��184��6-   $	 328��6:   $	 414��6L   $y�Visible=�6]   .+�5/      G� -   5         G�Name$ TxtPassWord��5/      $
��Left=�6/   $��2��6J   $��33��6W   $	��260��6c   
�������$��1q�6�    G� Password$  ��50      $��Center=�6   $��Center=�68    G� PasswordChar$ *��51      $��1��6"   $��12(�6/   $ 28��6=   $ 73��6N   $��28,0,0,0q�6^    J� RenderTransformOrigin$ 0.095,0.043&�52      ���#cccccc � ToolTip$ 请输入密码��6�    53        	HelpBrush  j� 
AlignmentX! !� Visual" �� TextAlignment��%�   &	       !� 54      $
  Left=�64   ! 55      �� 56      $��请输入密码��6&   $��28,0,0,0q�63   ���	#FFB2B2B2$��13(�6]   $��Center=�6k   
�������$
" Left=�6�   $	��175��6�   $��33��6�   $
��Left=�6�   58      59      5:      �� 5;      -   5        # ��Name$# txtUser��5;      $��33��6'   $ �� TextWrapping$
$ Wrap=�63   $	��260��6G   $��1��6S   $��1q�6`   $ 28��6�   $ 34��6�   ���	#FF6E6E6E$��28,0,0,0q�6�   $��Center=�6�   ���#cccccc$��Center=�6  �� 5<      % J� IsHitTestVisible% .  $��请输入用户名��61   $��33��6?   $	��260��6K   $��Center=�6W   $
��Left=�6r   
�������$ 28��6�   $ 34��6�   & �� Padding$& 31,9,0,0q�6�   ��5=      �� 5>      " ��6   .�5?      �� 	 � y�$
 	Collapsed=�67   ' �� Triggers' 5@      �� 5A      ( �� Binding( 6*   �� *Text+) �� ElementName$) txtUser��* �� Value*  6X   .a�5B   "   �� 	 � y�$
 Visible=�6?   5C      5E      5G      �� 5H      -	   5        + ��Name$+ chbPassWord��5H      $��记住密码��6,   $��3��6;   $��14��6H   $ 27��6T   $	 121��6e   $	��100��6v   ���	#FFA29D9D���	#FFCCCCCC6�   �� 5I      -
   5        $ label3��5I      $�� ��6$   $��22��6/   $ 34��6;   $ 78��6L   $��23��6\   ��5J      �� 5K      , j� Stretch$
, None=�6!   $1 +/Trace;component/Res_/images/密码-(1).png��60   5M      �� 5N      -   5        $ label4��5N      $�� ��6$   $��20��6/   $ 34��6;   $ 41��6L   $��22��6\   $ 1.273,1.475&�6g   ��5O      �� 5P      $- '/Trace;component/Res_/images/账号.png��6!   $
, None=�6S   5R      �� 5S      -   5        - ��Name$- imgbtnLogin��5S      $��4��6*   #���   67   $��72��6b   $��72��6n   $	 298��6�   $ 34��6�   ��6�   Z� ��6�   Z� ��5T      �� 5U      $+ %/Trace;component/Res_/Images/lg02.png��6!   5W      5X      �� 5^   
   -   5        $ 
TitleLabel��5^      $0��*武汉市农产品质量安全企业平台��6$   $��10,6,6,6q�6=   $��30��6P   $	��200��6\   $��13(�6h   ���	#FFF5F0F0$��Center=�6�   $��Center=�6�   �� 5_   
   -   5        $- btnClose��5_      $��5��6:   $��14��6G   $��14��6S   $	 991��6^   $ 8��6p   ��6   Z� ��6�   Z� ��5`      �� 5a      $, &/Trace;component/Res_/images/close.png��6   $
 Tile=�6R   5c      � 5d   
   -   5        . �Name$. progressbar1��5d      $��3��6,   $	 414��67   $
��1014��6H   
�������/ � Value$/ 0Q�6h   ���	#FFF7990D$y�Hidden=�6�   5e      5g      