   M S B A M L   `   `   `  ����P  LProgramowanie Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Programowanie_ProjektProgramowanie_Projekt  5   	   !    Programowanie_Projekt.Score   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Programowanie_Projekt     5   	     � Title$  Score��5   	   $	��400��6   $	��800��6$   
���   �.��5	      �  � RowDefinitions 5
   
   �� 5      $��2* �6   �� 5      $��4* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��2��6-   $ ��Gratulacje To Twój Wynik:��6B   
������$��40(�6|   $��Center=�6�   6�   �� 5   
   -   5        $��txtScore��5   D   $��1��6   $��0��6    $��2��60   
���   � �� 
IsReadOnly$
 True��6g   $��Center=�6y   
������$��Center=�6�   $	��100(�6�   6�   �� 5   
   $��2��6   $��0��6   $��Wpisz Imię:��6-   
������$��20(�6Y   6i   �� 5   
   -   5        $��txtName��5   /   $��3��6   $��0��6   
������
���   �$��20(�6g   6x   �� 5   
   -   5        $��btnOK��5   .   $��3��6   $��1��6   $��	Kontynuuj��6;      ButtonStyle1#���   6c   6�   5      5      