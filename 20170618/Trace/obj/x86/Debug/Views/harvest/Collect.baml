   M S B A M L   `   `   `  ����@  <Trace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Trace.Views.harvestTrace.Views.harvest  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   !    Trace.Views.harvest.Collect   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Trace.Views.harvest     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   -   5          � Title$  采收记录��5	   	   $	��310��6   $	��500��6#    � WindowStyle$
 None=�6/    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6\    � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Res_/Styles/MyForm.xaml?�6%   %    5      .��5      � $��0,0,2,1q�6   .+�5   
   �� -   5         ��Name$ label��5      $��采收操作��6   $
��Left=�6.   $��31��6I   $��12,5,0,0q�6U   $��15(�6g   $	��Top=�6u   $	��102��6�   $
��Bold"�6�   �� 5   
   
�������$��0,1,0,0q�6*   $
��Left=�6D   $��3��6_   $	��Top=�6j   $	��500��6�   $��	1,36,-3,0q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� 	 �� ScaleY$	 -1Q�6%   �� 5      
 �� AngleY$
 -0.002Q�6$   �� 5      T� 5       T� Y$ -0.016Q�6)   5      5      �� 5   
   -   5        $ label1��5      $��生产记录：��6    $
��Left=�60   $��30��6K   $��	39,56,0,0q�6W   $	��Top=�6j   $��66��6�   $ -0.389,-1.444&�6�   �� 5   
   -   5         ��Name$ 
production��5       �� SelectedValuePath$ PRODUCTION_ID��6'    �� DisplayMemberPath$ SHUOM��6I      ComboBoxStyle#��[  6c   $
��Left=�6�   $��
127,56,0,0q�6�   $	��Top=�6�   $��30��6�   $	��209��6�   6�   �� 5!   
   -   5        $ mydate��5!      $��采收日期：��6    $
��Left=�60   $��
39,106,0,0q�6K   $	��Top=�6_   $��66��6w   (  "System.Windows.Controls.DatePicker  5"   
   -   5          Name$ harvestDate��5"      
 �� Now   SelectedDate# Z 6*      SelectedDateFormat$
 Long=�6U   $
��Left=�6o   $��127,101,0,0q�6�   $	��Top=�6�   $��30��6�   $	��212��6�   �� 5$   
   -   5        $ label6��5$      $��	备注：��6    $
��Left=�6.   $��26��6I   $��
39,150,0,0q�6U   $	��Top=�6i   $��45��6�   �� 5%   
   -   5         ��Name$ remark��5%      $
��Left=�6"   $��52��6=   $��127,148,0,0q�6I    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��208��6�   �� 5'   
   -	   5        $ hidProId��5'      $y�Hidden=�6$   $
��Left=�68   $��23��6S   $��372,208,0,0q�6_   $
 Wrap=�6t   $	��Top=�6�   $	��120��6�   �� 5)   
   
�������$��0,1,0,0q�6*   $
��Left=�6D   $��4��6_   $	��Top=�6j   $	��500��6�   $��
0,229,-2,0q�6�   $ 0.5,0.5&�6�   z�5*      V� 5+      .~�5,      �� $	 -1Q�6%   �� 5-      �� 5.      T� 5/      50      52      �� 53   
   -
   5         ��Name$ 	btnSubmit��53      $��提 交��6$     styleSubmit#��[ 62   $
��Left=�6X   $��408,248,0,0q�6s   $	��Top=�6�   $��0q�6�   $��14(�6�   $��31��6�   $��54��6�   ���	#FFF5EFEF$
��Bold"�6  ��54      �� 55       �� EndPoint$	 0,1&�6&    �� 
StartPoint$	 0,0&�65   .��56      �  � Color$ 	#FFF3F3F3��6#    � Offset$ 0.997Q�65   � 57      $ 	#FFEBEBEB��6#   $ 1Q�65   � 58      $ 	#FFDDDDDD��6#   $ 1Q�65   � 59      $ 	#FF35BF3B��6#   $ 1Q�65   � 5:      $ 	#FF219126��6#   $ 0.952Q�65   5;      5=      �� 5>   
   -   5        $ 	btnCancel��5>      $��取 消��6$    
 style3#��[ 62   $
��Left=�6R   $��321,248,0,0q�6m   $	��Top=�6�   $��0q�6�   $��14(�6�   $��31��6�   $��52��6�   $ 
0.36,0.516&�6�   $
��Bold"�6�   ��5?      �� 5@      $	 0,1&�6&   $	 0,0&�65   .��5A      � $ 	#FFF3F3F3��6#   $ 0.997Q�65   � 5B      $ 	#FFEBEBEB��6#   $ 1Q�65   � 5C      $ 	#FFDDDDDD��6#   $ 1Q�65   � 5D      $ 	#FFCDCDCD��6#   $ 1Q�65   5E      5G      5K      5L      