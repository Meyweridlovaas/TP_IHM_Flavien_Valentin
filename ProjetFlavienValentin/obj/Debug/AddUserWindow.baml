   M S B A M L   `   `   `  ����  ProjetFlavienValentin)    #ProjetFlavienValentin.AddUserWindow   5	   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5
   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Créer un compte��5   	   $	��300��6!   $	��300��6.    � 
ResizeMode$ NoResize=�6:   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��Nom d'utilisateur : ��6   $��Center=�6/   $��Center=�6L   �� 5   
   $��Mot de passe : ��6   $��1��6*   $��Center=�67   $��Center=�6T   �� 5   
   $��Confirmer mot de passe : ��6   $��2��64   $��Center=�6A   $��Center=�6^   �� 5   
   $��1��6   $��5q�6"   ��6-   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��1��6   $��1��6"   $��5q�60   ��6;   �� *
Password+$ PropertyChanged=��� 5   
   $��1��6   $��2��6"   $��5q�60   ��6;   �� *ConfirmPassword+$ PropertyChanged=��� 5   
   $��3��6   $��2��6   $��Importer liste XML��62   $��5q�6O   $	��140��6Z   ��6f   �� *AddListCommand+�� 5    
   $��1��6   $��4��6!   $��5q�6.   $��Annuler��69   ��6K   �� *CancelCreateCommand+�� 5!   
   $��4��6   $��5q�6   $��Créer compte��6)   ��6@   �� *ConfirmCreateCommand+5"      5#      