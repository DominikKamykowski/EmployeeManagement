   M S B A M L   `   `   `  ����M  IEmployeeManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EmployeeManagementEmployeeManagement  5   	   #    EmployeeManagement.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:EmployeeManagement     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DGEmployeesData��5
      $
��Left=�6,   $	��400��6G   $��
120,10,0,0q�6T   $	��Top=�6h   $	��664��6�   �� 5   
   $��Opcje:��6   $
��Left=�6!   $��	10,10,0,0q�6<   $	��Top=�6O   $	��100��6g   $��Center=�6s   �� 5   
   -   5         ��Name$ BtnAddEmployee��5      $��Dodaj��6)   $
��Left=�69   $��	10,41,0,0q�6T   $	��Top=�6g   $	��100��6   $��25��6�   6�   �� 5   
   -   5        $ BtnEditEmployee��5      $��Edytuj��6*   $
��Left=�6;   $��	10,71,0,0q�6V   $	��Top=�6i   $	��100��6�   $��25��6�   6�   �� 5   
   -   5        $ BtnDeleteEmployee��5      $��Usuń��6,   $
��Left=�6;   $��
10,101,0,0q�6V   $	��Top=�6j   $	��100��6�   $��25��6�   6�   �� 5   
   -   5        $ BtnRefreshDataGridView��5      $��	Odśwież��61   $
��Left=�6C   $��
10,131,0,0q�6^   $	��Top=�6r   $	��100��6�   $��25��6�   6�   5      5      