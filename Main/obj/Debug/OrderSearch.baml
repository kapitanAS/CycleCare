   M S B A M L   `   `   `  ����  Main    Main.OrderSearch   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  OrderSearch��5   	   $	��500��6   $	��600��6*   .��5      �  � RowDefinitions 5   
   �� 5      $	��120 �6   �� 5      .+�5
   
   �� -   5        $��	fNameText��5
      $
��Left=�6#   $��40��6>   $��	25,50,0,0q�6J   $��0��6]    �� TextWrapping$
 Wrap=�6j   $	��Top=�6~   $	��120��6�   $��Calibri)�6�   $��20(�6�   �� 5   
   -   5        $��
fNameLabel��5      $��
First Name��6"   $
��Left=�67   $��	25,20,0,0q�6R   $��0��6e   $	��Top=�6r   $��Calibri)�6�   $��20(�6�   �� 5   
   -   5        $��	lNameText��5      $
��Left=�6#   $��40��6>   $��
180,50,0,0q�6J   $��0��6^   $
 Wrap=�6k   $	��Top=�6�   $	��200��6�   $��Calibri)�6�   $��20(�6�   �� 5   
   -   5        $��
lNameLabel��5      $��	Last Name��6"   $
��Left=�66   $��
180,20,0,0q�6Q   $��0��6e   $	��Top=�6r   $��Calibri)�6�   $��20(�6�   �� 5   
   -   5        $��openOrdersButton��5      $��Open Orders��6)   $
��Left=�6?   $��
400,25,0,0q�6Z   $��0��6n   $	��Top=�6{   $	��140��6�   $��35��6�   $��Calibri)�6�   $��20(�6�   6�   �� 5   
   -   5        $��historicalOrdersButton��5      $��Historical Orders��6/   $
��Left=�6K   $��
400,75,0,0q�6f   $��0��6z   $	��Top=�6�   $	��140��6�   $��35��6�   $��Calibri)�6�   $��20(�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��
OrdersList��5      $��1��6%      SelectionMode$ Single=�62   6I   5       � 	Resources 5         ItemCollectionViewSource �� CollectionViewType��%"   &	        �� 5   
   " ��6@   5      5      