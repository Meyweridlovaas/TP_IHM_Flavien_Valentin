   M S B A M L   `   `   `  ���� P  LProjetFlavienValentin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ProjetFlavienValentin.ConverterProjetFlavienValentin.Converter  &     ProjetFlavienValentin.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     C	converter-clr-namespace:ProjetFlavienValentin.Converter       � Title$;  530 millions d'amis : l'application presque officielle��$	��350��$	��525��$	��320��$	��400��.���  � 	Resources A   ;ProjetFlavienValentin.Converter.Bool2ColorReadOnlyConverter   
Bool2Color?   9ProjetFlavienValentin.Converter.Bool2Visibility1Converter  Bool2Visibility1?   9ProjetFlavienValentin.Converter.Bool2Visibility2Converter  Bool2Visibility29   3ProjetFlavienValentin.Converter.String2UriConverter  
String2Uri��%<   &	        &	      &	 
     &	               � RowDefinitions �� $
��1.5* ��� $��8* ��� $��2* �.+��� $;��530 millions d'amis : l'application presque officielle��$��Center=�$��5q�$��14(�� $��1�� � ColumnDefinitions �� $��3* ��� $��7* �.+��� $��5,0,0,0q����� *ListAnimals+ �� SelectedItem �� *Animal+{��� *
IsReadOnly+���� .R��� ���� *Name+� $��1�� �� $��2* ��� $��2* ��� $��4* � �� $��1* ��� $��1* ��� $��3* �.+��� $	��Nom��$��50��$��Center=�$��Center=��� $��1��$
��auto��$��30��$��10q����� *Name+ �� UpdateSourceTrigger$ PropertyChanged=� �� 
IsReadOnly �� *
IsReadOnly+���� *
IsReadOnly+ �� 	Converter# [  �� $��Famille��$��50��$��1��$��Center=�$��Center=��� $��1��$��1��$
��auto��$��30��$��10q����� *Family+$ PropertyChanged=� �� *
IsReadOnly+���� *
IsReadOnly+# [  �� $��2��$��2��$��0,0,5,0q����� *Animal.ImageSource+# [  � ContextMenu �� .@�m� $��Changer d'image��	 m� Command	 �� *ChangeImageCommand+�� $��2��$��3��$��5q����� *Description+$ PropertyChanged=� �� *
IsReadOnly+���� *
IsReadOnly+# [  � $��2�� �� �� �� .+��� $��10q�$��Ajouter������ *
AddCommand+� $��1�� �� �� .+��� $��10q�$��2��$��Editer������ *EditCommand+y��� *
IsReadOnly+# [ �� $��10q�$��Enregistrer��y��� *
IsReadOnly+# [ ���� *SaveCommand+�� $��10q�$��Annuler��$��1��y��� *
IsReadOnly+# [ ���� *CancelCommand+�� $��10q�$��2��$��	Supprimer������ *DeleteCommand+