   M S B A M L   `   `   `  ����@  <Trace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Trace.Views.productionTrace.Views.production  5   	   9!clr-namespace:Trace.TreeViewModelTrace.TreeViewModel  5   	   0    *Trace.Views.production.ProductConfigureAdd   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Trace.Views.production     5   	   0vm!clr-namespace:Trace.TreeViewModel     5   	     � Title$  ProductConfigureAdd��5	   	   $��478.55��6%   $��654.161��65    � WindowStyle$
 None=�6E    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6r    � 	Resources 5       �� 
TargetType 
  style3 �� Property �� Value �� 
TargetType	 ��Name
 J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName �� Triggers  MyTreeItemTemplate �� DataType#   Trace.TreeViewModel.TreeModel �� ItemsSource ��Name �� Orientation d� 	IsChecked  TreeViewItemStyle �� Path �� Mode  styleConfirmed��%�
  &	        &	 �    &	 }    &	     �� 5   
   " ��6   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � |� .  6*   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� �#0006+   �� 5       � ��$ 14(�6)   �� 5       � �� �	#FF5AD36B6+   �� 5       � �� �#9996,   �� 5       � ��$ 1q�60   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 25��6'   �� 5       � ��$ 60��6&   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $	 Chrome��6!   $��0q�61   #��z��6E   #��z��6q   
 . ._�5      �� #��z��6/   #��z��6r   ��. #
 z
 5   <   #��z��5    !   5!       5"      P� 5#       � {� .  . �5$   "   ��  � �� �#ADADAD6?   5%      P� 5&       �@J�IsMouseOver . . �5'   "   �� $ Chrome��6)    � �� �#FF00006S   �� 5(   "    � ��
 �����6?   5)      5,      5.       5/      P� 50       �@J�IsMouseOver . . �51      ��  � �� �#99963   �� 52       � �� �#fff63   53      55      �� 56   
   "  6?    57      �� *
Children+.R�58      �� $ My_SP��6   $ 
Horizontal=�6)   $��2q�6B   .+�59      ��  6   �� *	IsChecked+5:      �� 5;      $	��2,0q�6=   ��6$   �� *Name+6=   5<      5=      �� 5>   
   " Q�6*   .�5?      ��  �@Q�
IsExpanded . 6+   �� 5@       �@Q�
IsSelected 6+   �� $ 
IsSelected�$ TwoWay=�5A      �� 5B   
   " ��6   .�5C      ��  �@�OverridesDefaultStyle . 66   �� 5D       � |� .  6*   �� 5E       �@�Cursor$
 Hand��6'   �� 5F       � �� �#0006+   �� 5G       � ��$ 14(�6)   �� 5H       � �� �#f4f4f46+   �� 5I       � �� �#9996,   �� 5J       � ��$ 1q�60   �� 5K       � ��$ Center=�6;   �� 5L       � ��$ Center=�69   �� 5M       � ��$ 25��6'   �� 5N       � ��$ 60��6&   �� 5O       � �� 5P      �� 5Q      " ��6&   .R�5R      �� $	 Chrome��6!   $��0q�61   #��z��6E   #��z��6q   
 . ._�5S      �� #��z��6/   #��z��6r   ��. #
 z
 5T   <   #��z��5U   !   5V       5W      P� 5X       � {� .  . �5Y   "   ��  � �� �#ADADAD6?   5Z      P� 5[       �@J�IsMouseOver . . �5\   "   �� $ Chrome��6)    � �� �#00FF006S   �� 5]   "    � ��
 �����6?   5^      5a      5c       5d      P� 5e       �@J�IsMouseOver . . �5f      ��  � �� �	#FF23AA3663   �� 5g       � �� �#fff63   5h      5j      5k      .��5m      � $
��Left=�6   $	��654��6&    � RowDefinitions 5n   
   �� 5o      $��* �6   �� 5p      $
��auto �6   .+�5r   
   ]� $��	0,-6,0,82q�6   .+�5s      R� -   5         R�Name$ tvwProductConfigure��5s      
���   �#��[ 5u      #��[ 5v      $	��654��6J   $��	0,47,0,-1q�6V   ��5t      �� *
Children+5v   V   5w      �� 5x   
   -   5         ��Name$ label��5x      $��企业农产品��6   $
��Left=�6/   $��27��6J   $��40,4,0,0q�6V   $��13(�6h   $	��Top=�6v   $��77��6�   �� 5y   
   
�������$��0,1,0,0q�6*   $
��Left=�6D   $��3��6_   $	��Top=�6j   $	��655��6�   $��	-1,30,0,0q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5z      V� 5{      .~�5|      ��  �� ScaleY$ -1Q�6%   �� 5}      �� 5~      T� 5      5�      5�      �� 5�   
   -   5         ��Name$ 	btnCancel��5�      $��取 消��6$   #��[  62   $��473,429,87,0q�6R   $	��Top=�6h   $��0q�6�   $��14(�6�   $��41��6�   $
��Auto��6�   $ 
0.36,0.516&�6�   $
��Bold"�6�   ��5�      �� 5�       �� EndPoint$	 0,1&�6&    �� 
StartPoint$	 0,0&�65   .��5�      �  � Color$ 	#FFF3F3F3��6#     � Offset$  0.997Q�65   � 5�      $ 	#FFEBEBEB��6#   $  1Q�65   � 5�      $ 	#FFDDDDDD��6#   $  1Q�65   � 5�      $ 	#FFCDCDCD��6#   $  1Q�65   5�      5�      �� 5�   
   -   5        $ btnConfirmed��5�      $��确 定��6'   #��[ 65   $
��Left=�6^   $��348,430,0,0q�6y   $	��Top=�6�   $��0q�6�   $��14(�6�   $��39��6�   $	��106��6�   ���	#FFF5EFEF$
��Bold"�6  ��6�   �� *	OKCommand+��5�      �� 5�      $	 0,1&�6&   $	 0,0&�65   .��5�      � $ 	#FFF3F3F3��6#   $  0.997Q�65   � 5�      $ 	#FFEBEBEB��6#   $  1Q�65   � 5�      $ 	#FFDDDDDD��6#   $  1Q�65   � 5�      $ 	#FF35BF3B��6#   $  1Q�65   � 5�      $ 	#FF219126��6#   $  0.952Q�65   5�      5�      �� 5�   
   
�������$��0,1,0,0q�6*   $
��Left=�6D   $��3��6_   $	��Top=�6j   $	��655��6�   $��
-1,418,0,0q�6�   $ 0.5,0.5&�6�   z�5�      V� 5�      .~�5�      �� $ -1Q�6%   �� 5�      �� 5�      T� 5�      5�      5�      �� 5�   
   -   5        $ label1��5�      $��Label��6    $
��Left=�60   $��27��6K   $��15,5,0,0q�6W   $	��Top=�6i   $��39��6�   $ 0.658,0.573&�6�   5�      5�      