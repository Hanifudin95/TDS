   M S B A M L   `   `   `  ����  	TDSClient%    TDSClient.Forms.frmMapWMSLayers   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  frmMapWMSLayers��5   	   $	��417��6!   $	��540��6.   $��Global User Interface)�6:   $��11(�6]    � 
ResizeMode$ NoResize=�6k   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGridLayerName��5   M   
������ $	��306��6,   $��
4,0,59.6,0q�69      RowBackground
 ���� $	��Top=�6�   �� 5   
   -   5        $��cmdUp��5   Q   
������ $��0,37,9,0q�6+   $��37��6^   $	��Top=�6j   $��Right=�6�   $��42��6�   .��5	      �� $��25��6   $��Stretch=�6    $.��(pack://application:,,,/images/UpIcon.png��6>   $��Stretch=�6p   $��39��6�   5
      �� 5   
   -   5        $��cmdDown��5   R   
������ $��0,74,9,0q�6*   $��37��6a   $	��Top=�6m   $��Right=�6�   $��42��6�   .��5      �� $��25��6   $��Stretch=�6!   $0��*pack://application:,,,/images/DownIcon.png��6A   $��39��6u   5      �� 5   
   -   5         ��Name$ buttonOK��5   e   $��OK��6   $
��Left=�6   $��466,0,0,7.2q�69   $��55��6w   $��20��6�   $��Bottom=�6�   �� 5   
   -   5        $ cmdSaveUser��5   g   $��20��6   $
��Left=�6   $��228,0,0,7.2q�68   $��Bottom=�6|   $��55��6�   .��5      �� $,��&pack://application:,,,/images/user.png��6   5      �� 5   
   -   5         ��Name$ lblSaveUser��5   |   }�. $��Save Maps to User��6$   $��23��6@   $
��Left=�6L   $��113,0,0,6.2q�6g   $��Bottom=�6�   $	��103��6�   �� 5   
   -   5         ��Name$ trackTransparant��5   L   $
��Left=�6   $��
10,319,0,0q�6,    � Maximum$ 1Q�6@    �� TickFrequency$	 0.1Q�6f    �� TickPlacement$ BottomRight=�6z   $	��274��6�   $��25��6�   $	��Top=�6�   6�   �� 5   
   -   5        $ label1��5   v   }�. $��Transparency��6$   $��23��6;   $
��Left=�6G   $��
10,283,0,0q�6b   $	��Top=�6�   $��82��6�   �� 5   
   -	   5        $ 
btnRefresh��5      $��Right=�6%   $��29��6A   $��	0,229,9,0q�6M   $	��Top=�6`   $��42��6x   .��5      �� $>��8pack://application:,,,/images/Button_Refresh_Icon_32.png��6   5      �� 5   
   -
   5        $��btnSaveZoom��5      $��	Save Zoom��6$   $
��Left=�68   $��311,362,0,0q�6S   $	��Top=�6h   $��20��6�   $��75��6�   6�   5      5      