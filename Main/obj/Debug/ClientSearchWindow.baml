   M S B A M L   `   `   `  ����  Main    Main.ClientSearchWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ClientSearchWindow��5   	   $	��300��6$   $	��300��61   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5
   
   � $��0��6    5      �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� -   5        $��customerSearchText��5      $��0��60   $��0��6=   $
��Left=�6N   $��20��6i   $��	10,10,0,0q�6u    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��100��6�   6�   �� 5      -   5        $��addCustomerButton��5      $��Add Customer��6.   $��1��6E   $��Right=�6U   $��	10,10,0,0q�6q   $	��Top=�6�   $��90��6�   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��
clientList��5      $��1��6%      SelectionMode$ Single=�62   6I   5      5      