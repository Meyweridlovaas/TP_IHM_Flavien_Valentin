   M S B A M L   `   `   `  ����  ProjetFlavienValentin0    *ProjetFlavienValentin.ChangePasswordWindow   5	   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5
   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Changer de mot de passe��5   	   $	��200��6)   $	��300��66    � 
ResizeMode$ NoResize=�6B   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��Ancien mot de passe : ��6   $��Center=�61   $��Center=�6N   �� 5   
   $��Nouveau mot de passe : ��6   $��1��62   $��Center=�6?   $��Center=�6\   �� 5   
   $��Confirmer mot de passe : ��6   $��2��64   $��Center=�6A   $��Center=�6^   �� 5   
   $��1��6   $��4q�6"   ��6-   �� *OldPassword+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��1��6   $��1��6"   $��4q�6/   ��6:   �� *
Password+$ PropertyChanged=��� 5   
   $��1��6   $��2��6"   $��4q�6/   ��6:   �� *ConfirmPassword+$ PropertyChanged=��� 5   
   $��3��6   $��2��6   $��Changer de mot de passe��62   $��5q�6T   $	��160��6_   ��6k   �� *ChangePassCommand+5      5       