   M S B A M L   `   `   `  ����I  EAccessWorkshop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:AccessWorkshop.Views.Pages.Admin AccessWorkshop.Views.Pages.Admin  5      4    .AccessWorkshop.Views.Pages.Admin.AdminViewPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:AccessWorkshop.Views.Pages.Admin     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  AdminViewPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $��* �6   �� 5      $
��0.4* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��0.5* �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $
��Left=�5      $	��Top=�5      $��30,0,0,0q�5      .+�5      �� -   5         ��Name$ btn_Exit��5      $��50��5       
������ 
������ ���#a3a3a3+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5$      $	��100��5%      .��5'      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Power=�6.   $��65��5(   .   $��35��5)   .   5*      5+      �� 5,      $��1��6    �� Orientation$ 
Horizontal=�5-      $��Center=�5.      $��Center=�5/      .+�50      �� -   5         ��Name$ 	txb_Searh��50      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск��51      $��18(�52      $	��200��53      �� 54      -   5        	 ��Name$	 cmb_WorkShop��54      $+ %Выберите мастерскую��55      $��	10,0,20,0q�56      $��16(�57      $	��350��58      �� 5:      -   5        $ btn_ResetFilter��5>      
������ 
������ ���#a3a3a3$��0,0,10,0q�5=      .��5?        $ Reload=�6.   $��35��5@   .   $��25��5A   .   5B      5D      5E      � 5G   
   $��2��6    5H      �� 5I      $��* �6#   �� 5J      $��* �6#   .+�5M      �� $��0��6   $ 
Horizontal=�5N      .+�5O      �� -   5        $ btn_Add��5O      $��Добавить��5P      $ 10��5Q      $��10,0,0,0q�5R      $	��200��5S      $��18(�5T      $��50��5U      �� 5V      -   5        $ btn_Edit��5V      $��10,0,0,0q�5W      $��50��5X      $��18(�5Y      $ ��Редактировать��5Z      $	��200��5[      $ 10��5\      �� 5]      -   5        $ 
btn_Remove��5]      $��10,0,0,0q�5^      $��50��5_      $��18(�5`      $��Удалить��5a      $	��200��5b      $ 10��5c      5d      5e      � 5g   
   $��1��6   .+�5h      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 
dbDataView��5h         AutoGenerateColumns .     
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5k         Columns 5m      0  *System.Windows.Controls.DataGridTextColumn  5n      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width$
 0.3* 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *ID+6L     5o      $ Фамилия��6)   $
 0.5* 6W    6:   �� *
LastName+6W     5p      $ Имя��6)   $
 0.5* 6T    66   �� *	FirstName+6T     5q      $ Отчество��6)   $
 0.5* 6Z    6;   �� *
Patronymic+6Z     5r      $ Пол��6)   $
 0.5* 6W    66   �� *Gender.Title+6W     5s      $ Отделение��6)    6<   �� *Group.Department.Title+  5t      $ Курс��6)   $
 0.3* 6a    67   �� *Group.Course.CourseID+6a     5u      $ Мастерска��6)    6<   �� *WorkShop.Compitation+  5v      $ Email��6)   $
 0.5* 6R    68   �� *Email+6R     5w      $ Телефон��6)   $
 0.5* 6T    6:   �� *Phone+6T   5y      5z      5|      5}      