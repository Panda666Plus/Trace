   M S B A M L   `   `   `  ����@  <Trace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Trace.Views.mainTrace.Views.main  5   	       Trace.Views.main.Main   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Trace.Views.main     5   	   -   5          � Icon$.  (/Trace;component/Res_/images/favicon.ico��5       � Title$H B武汉市农产品质量安全企业平台 - 种植企业子系统��5   	   $	��614��6*   $
��1030��67   $��8q�6D    � WindowStartupLocation$ CenterScreen=�6X    � AllowsTransparency .  � WindowStyle$
 None=�6  ��6   Z�  J� Effect 5	      3  -System.Windows.Media.Effects.DropShadowEffect  5
   
      
BlurRadius$ 13Q�6      Color$ 	#FF7F9DB9��6+      ShadowDepth$ 0Q�6=   .��5      �� ���#CCCCCC.+�5   
   �� $��30��6   $
��1012��6   ���#2d8931	 �� Left$	 1��6?   

 �� Top$
 1��6O   .+�5      �� -   5         ��Name$ label��5      $H��B武汉市农产品质量安全企业平台 - 种植企业子系统��6#   $��30��6F   $��13(�6R   $��10,6,6,6q�6`   ���	#FFF5F0F0$
��Left=�6�   �� 5      -   5         ��Name$ btnClose��5      $��12��6>   $��12��6J    J� 	AllowDrop .  $		 991��6g   $
 9��6y   ��6�   Z� ��6�   Z� ��5      �� 5       �� ImageSource$, &/Trace;component/Res_/images/close.png��6!    j� TileMode$
 Tile=�6V   5      5       � 5   
   -   5          �Name$ 	MainFrame��5      $��	主界面��6#   $	��567��61   $
 31��6>   $
��1012��6N   $	 1��6[     � NavigationUIVisibility$ Hidden=�6k   
�������6�    � 5   
   -   5        $ ProductFrame��5      $��产品档案��6&   $	��567��65   $
 31��6B   $
��1012��6R   $	 1��6_   $y�Hidden=�6o   $ Hidden=�6�    � 5   
   -   5        $ FunctionFrame��5      $��功能菜单��6'   $	��567��66   $
 31��6C   $
��1012��6S   $	 1��6`   $y�Hidden=�6p   $ Hidden=�6�    � 5   
   -   5        $ 	UserFrame��5      $��用户信息��6#   $	��567��62   $
 31��6?   $
��1012��6O   $	 1��6\   $y�Hidden=�6l   $ Hidden=�6�   5N      5O      