   M S B A M L   `   `   `  ����P  LProgramowanie Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Programowanie_ProjektProgramowanie_Projekt  5   	   &     Programowanie_Projekt.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Programowanie_Projekt     5   	     � Title$  Quizz��5   	    � WindowState$ 	Maximized=�6    � WindowStyle$
 None=�6/   $��40(�6B   
���   �.��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��4* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��190* �6   �� 5      $
��190* �6   �� 5      $
��190* �6   �� 5      $
��190* �6   �� 5      $
��129* �6   .+�5   
   o� -   5        $��Menu1��5      $��0��6   $��0��6)   $��Center=�69   $��4��6V    
  Simple#���   6j   .@�5      m� -   5          Triggers#���  5      $��Utwórz��6:   6J   m� 5      -   5        #���  5      $��Zaktualizuj��6:   6O   m� 5      -   5        #���  5      $��Usuń��6:   6H   m� 5      -   5        #���  5      $
��Quiz��6:   6H   m� 5      -   5        #���  5      $��Zamknij��6:   6K   5       �� 5$   
   $��Tablica Wyników:��6   $��1��6+   $��1��68   $��2��6H   $��Black"�6\   
������$��Center=�6�   �� 5&   
   -   5        $��txtLeadboard��5&      $��1��6&   $��0��63   $��4��6C    �� 
IsReadOnly$
 True��6W   $��Center=�6j   $	��760��6�   
���   �
��� ���$��0,63,0,0q�6�   $��2��6�   5*      5+      