   M S B A M L   `   `   `  ����B  >sisTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:sisTasksisTask  5   	       sisTask.AccessWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:sisTask     5   	     � Title$  AccessWindow��5   	   $	��450��6   $	��801��6+   .��5	      � $��	0,0,0,-16q�6   .+�5
   
   �� -   5        $��
ProfileBtn��5
      $��Профиль��6#   $��0,5,554,402q�6N   $��Right=�6c   $	��237��6   �� 5   
   -   5        $��	ResultBtn��5      $��
Отчёт��6"   $��10,53,554,341q�6K   �� 5   
   -   5        $��ProfilesBtn��5      $��Пользователи��6$   $��558,5,10,402q�6U   �� 5   
   -   5        $��
HistoryBtn��5      $#��История заданий��6#   $��252,4,248,402q�6V   �� 5   
   -   5        $��	SearchBtn��5      $��
Поиск��6"   $��558,53,10,341q�6J   �� 5   
   -   5        $��Search��5      $��252,53,248,341q�6    ���	#FFE3FFDF68   &   System.Windows.Controls.DataGrid  5   
   -   5        $��TaskGrid��5         AutoGenerateColumns$ False��6#      CanUserAddRows$ False��6?      
IsReadOnly$
 True��6V   $��10,114,10,24q�6h      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5      $ Название��6%   $ * 6Q    67   �� *Title+6Q     5      $ Описание��6%   $ * 6S    67   �� *	Writing+6S     5      $ Дата��6%   $ 50 6L    63   �� *Data+6L     5      $ 
Автор��6%   $ 80 6a    64   �� *IdAuthorNavigation.Login+6a   5      5      5      