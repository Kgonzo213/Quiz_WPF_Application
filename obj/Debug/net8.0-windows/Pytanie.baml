   M S B A M L   `   `   `  ����P  LProgramowanie Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Programowanie_ProjektProgramowanie_Projekt  5      #    Programowanie_Projekt.Pytanie   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Programowanie_Projekt     5        N� Title$  Pytanie��5	       N� FontSize$ 20(�6   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��9* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Kategoria Pytania:��6   $��0��6-   $��0��6:   $��Black"�6J   �� 5   
   -   5        $��cmbCategory��5      $��0��6&   $��1��63    �� 
IsReadOnly$
 True��6C   �� 5   
   $��Treść Pytania:��6   $��0��6)   $��2��66   $��2��6F   $��Black"�6Z   �� 5   
   -   5        $��txtQuestion��5      $��1��6%   $��2��62   $��2��6B    �� 
IsReadOnly$
 True��6W   �� 5    
   -   5        $��imgImage��5       $��1��6    $��0��6-   $��2��6=   �� 5"   
   $��Odpowiedzi:��6   $��2��6&   $��0��63   $��Black"�6C   $��Right=�6V   �� 5#   
   $��A��6   $��2��6   $��1��6)   $��Black"�69   �� 5$   
   -   5        $��chcbA��5$      $��2��6    $��1��6-   $��	18,7,0,13q�6=   �� 5%   
   -   5        $��
txtAnswerA��5%      $��2��6$   $��1��61   $��
45,7,15,13q�6B   $
 True��6V   �� 5'   
   $��B��6   $��2��6   $��2��6)   $��Black"�69   �� 5(   
   -   5        $��chcbB��5(      $��2��6    $��2��6-   $��	18,7,0,13q�6=   �� 5)   
   -   5        $��
txtAnswerB��5)      $��2��6$   $��2��61   $��
45,7,15,13q�6B   $
 True��6W   �� 5+   
   $��C��6   $��2��6   $��3��6)   $��Black"�69   �� 5,   
   -   5        $��chcbC��5,      $��2��6    $��3��6-   $��	18,7,0,13q�6=   �� 5-   
   -	   5        $��
txtAnswerC��5-      $��2��6$   $��3��61   $��
45,7,15,13q�6B   $
 True��6W   �� 51   
   -
   5        $��	btnUpload��51   8      ButtonStyle1#���   6   $��Wczytaj zdjęcie��6I   $��3��6c   $��0��6p   $��2q�6�   �� 52   
   -   5        $��btnNext��52   8   #���   6   $��	Następne��6G   $��3��6Z   $��3��6g   $��2q�6w   55      56      