   M S B A M L   `   `   `  ����P  LProgramowanie Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Programowanie_ProjektProgramowanie_Projekt  5   	   "    Programowanie_Projekt.Delete   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Programowanie_Projekt     5   	     � Title$  Delete��5   	   $	��450��6   $	��800��6%   
���   �$��Italic$�6D   
�������.��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��9* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Wybierz Pytanie:��6   $��0��6+   $��0��68   $��Black"�6H   
������6[   �� 5   
   -   5        $��cmbQuestion��5      $��0��6&   $��1��63   $��2��6C   
�������
������ �� DisplayMemberPath$ Question��6�    �� SelectedValuePath$ Id��6�   �� 5   
   $��Treść Pytania:��6   $��0��6)   $��3��66   $��2��6F   $��Black"�6Z   
������6m   �� 5   
   -   5        $��txtQuestion��5      $��1��6%   $��2��62   $��2��6B    �� 
IsReadOnly$
 True��6V   
�������
���   � �� TextWrapping$ WrapWithOverflow=�6�    �� AcceptsReturn$
 True��6�   �� 5   
   -   5        $��imgImage��5      $��1��6    $��0��6-   $��2��6=   �� 5   
   $��A��6   $��2��6   $��0��6)   $��Black"�69   
������6L   �� 5    
   -   5        $��
chkAnswerA��5       $��2��6%   $��0��62   $��	18,7,0,13q�6B   
�������6U   �� 5!   
   -   5        $��
txtAnswerA��5!      $��2��6$   $��0��61   $��
45,7,15,13q�6B   $
 True��6V   
�������6h   �� 5#   
   $��B��6   $��2��6   $��1��6)   $��Black"�69   
������6L   �� 5$   
   -   5        $��
chkAnswerB��5$      $��2��6%   $��1��62   $��	18,7,0,13q�6B   
�������6U   �� 5%   
   -   5        $��
txtAnswerB��5%      $��2��6$   $��1��61   $��
45,7,15,13q�6B   $
 True��6W   
�������6i   �� 5'   
   $��C��6   $��2��6   $��2��6)   $��Black"�69   
������6L   �� 5(   
   -   5        $��
chkAnswerC��5(      $��2��6%   $��2��62   $��	18,7,0,13q�6B   
�������6U   �� 5)   
   -	   5        $��
txtAnswerC��5)      $��2��6$   $��2��61   $��
45,7,15,13q�6B   $
 True��6W   
�������6i   �� 5+   
   $��D��6   $��2��6   $��3��6)   $��Black"�69   
������6L   �� 5,   
   -
   5        $��
chkAnswerD��5,      $��2��6%   $��3��62   $��	18,7,0,13q�6B   
�������6U   �� 5-   
   -   5        $��
txtAnswerD��5-      $��2��6$   $��3��61   $��
45,7,15,13q�6B   $
 True��6W   
�������6i   �� 50   
   -   5        $��	btnUpload��50   8      ButtonStyle1#���   6   $��Wczytaj zdjęcie��6I   $��3��6c   $��0��6p   $��2q�6�     Button.Static.Foreground#���  6�   �� 51   
   -   5        $��	btnDelete��51   8   #���   6   $��Usuń��6I   $��3��6X   $��2��6e   $��2q�6u   #���  6�   6�   �� 52   
   -   5        $��btnClose��52   8   #���   6   $��Zamknij��6H   $��3��6Z   $��3��6g   $��2q�6w   #���  6�   �� 53   
   $��
Kategoria:��6   $��2��6%   $��1��62   $��Black"�6B   $��
3,28,88,19q�6U   $��2��6i   $��10(�6z   
������6�   �� 54   
   -   5        $��txtCategory��54      $��3��6%   $��1��62   $��
3,12,72,10q�6B   
�������
���   �6m   56      57      