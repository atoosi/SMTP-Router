   M S B A M L   `   `   `  ����E  ASMTPRouter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SMTPRouter
SMTPRouter  5   	        SMTPRouter.ReceiverSetting   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SMTPRouter     5   	     � Title$  ReceiverSetting��5   	   $��345.241��6!   $��879.958��62   .��5	      � $��0,0,2,0q�6   .+�5
   
   �� -   5         ��Name$ ListenAddresslabel��5
      $��Listen Address��6,   $
��Left=�6E   $��	10,18,0,0q�6`   $	��Top=�6s   $	��102��6�   �� 5   
   -   5         ��Name$ ListenAddresstextBox��5      $
��Left=�60   $��18��6K   $��
117,22,0,0q�6W    �� TextWrapping$
 Wrap=�6k   $��0.0.0.0��6   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ ListenPortlabel��5      $��Listen Port��6)   $
��Left=�6?   $	��Top=�6Z   $��	10,51,0,0q�6r   $��25��6�   $	��102��6�   �� 5   
   -   5        $ ListenPorttextBox��5      $
��Left=�6-   $��18��6H   $��
117,54,0,0q�6T   $
 Wrap=�6h   $��25��6|   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ ReceiveTimeOutlabel��5      $��Receive Time Out��6-   $
��Left=�6H   $��	10,82,0,0q�6c   $	��Top=�6v   �� 5   
   -   5        $ ReceiveTimeOuttextBox��5      $
��Left=�61   $��18��6L   $��
117,86,0,0q�6X   $
 Wrap=�6l   $��0��6�   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ HostNamelabel��5      $��	Host Name��6'   $
��Left=�6;   $	��Top=�6V   $��
10,115,0,0q�6n   $��25��6�   $��77��6�   �� 5   
   -   5        $ HostNametextBox��5      $
��Left=�6+   $��18��6F   $��117,122,0,0q�6R   $
 Wrap=�6g   $��p49.questinc.com��6{   $	��Top=�6�   $	��120��6�   �� 5   
   -	   5        $ MaxDataSizelabel��5      $��Max Data Size��6*   $
��Left=�6B   $��
10,214,0,0q�6]   $	��Top=�6q   �� 5   
   -
   5        $ MaxMessageslabel��5      $��Max Messages��6*   $
��Left=�6A   $��
10,246,0,0q�6\   $	��Top=�6p   �� 5   
   -   5        $ StorePathlabel��5      $��
Store Path��6(   $
��Left=�6=   $��
256,18,0,0q�6X   $	��Top=�6l   �� 5   
   -   5        $ MaxSessionslabel��5      $��Max Sessions��6*   $
��Left=�6A   $��
256,51,0,0q�6\   $	��Top=�6p   �� 5   
   -   5        $ LogPathlabel��5      $��LogPath��6&   $
��Left=�68   $��
256,82,0,0q�6S   $	��Top=�6g    J� RenderTransformOrigin$ 
0.55,0.096&�6   �� 5   
   -   5        $ MaxDataSizetextBox��5      $
��Left=�6.   $��18��6I   $��117,218,0,0q�6U   $
 Wrap=�6j   $
��1024��6~   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ MaxMessagestextBox��5      $
��Left=�6.   $��18��6I   $��117,250,0,0q�6U   $
 Wrap=�6j   $��0��6~   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ StorePathtextBox��5      $
��Left=�6,   $��18��6G   $��
373,22,0,0q�6S   $
 Wrap=�6g   $��C:\smtprouter\��6{   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ MaxSessionstextBox��5      $
��Left=�6.   $��18��6I   $��
373,54,0,0q�6U   $
 Wrap=�6i   $��0��6}   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ LogPathtextBox��5      $
��Left=�6*   $��18��6E   $��
373,86,0,0q�6Q   $
 Wrap=�6e   $��C:\smtprouter\��6y   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ VerboseLogginglabel��5      $��Verbose Logging��6-   $
��Left=�6G   $��256,115,0,0q�6b   $	��Top=�6w   �� 5   
   -   5        $ DoEarlyTalklabel��5      $��Do Early Talk��6*   $
��Left=�6B   $��256,147,0,0q�6]   $	��Top=�6r   �� 5   
   -   5        $ RWLproviderslabel��5      $��RWLproviders��6+   $
��Left=�6B   $��256,182,0,0q�6]   $	��Top=�6r   �� 5   
   -   5        $ RBLproviderslabel��5      $��RBLproviders��6+   $
��Left=�6B   $��256,214,0,0q�6]   $	��Top=�6r   �� 5    
   -   5        $ MaxSmtpErrorslabel��5       $��Max Smtp Errors��6,   $
��Left=�6F   $��256,246,0,0q�6a   $	��Top=�6v   �� 5!   
   -   5        $ RWLproviderstextBox��5!      $
��Left=�6/   $��18��6J   $��362,185,0,0q�6V   $
 Wrap=�6k   $�� ��6   $	��Top=�6�   $	��120��6�   �� 5"   
   -   5        $ RBLproviderstextBox��5"      $
��Left=�6/   $��18��6J   $��362,218,0,0q�6V   $
 Wrap=�6k   $�� ��6   $	��Top=�6�   $	��120��6�   �� 5#   
   -   5        $ MaxSmtpErrorstextBox��5#      $
��Left=�60   $��18��6K   $��362,250,0,0q�6W   $
 Wrap=�6l   $��0��6�   $	��Top=�6�   $	��120��6�   �� 5$   
   -   5        $ MaxSmtpNooptextBox��5$      $
��Left=�6.   $��18��6I   $��
726,22,0,0q�6U   $
 Wrap=�6i   $��0��6}   $	��Top=�6�   $	��120��6�   �� 5%   
   -   5        $ MaxSmtpNooplabel��5%      $��Max Smtp Noop��6*   $
��Left=�6B   $��
624,18,0,0q�6]   $	��Top=�6q   �� 5&   
   -   5        $ MaxSmtpVrfylabel��5&      $��Max Smtp Vrfy��6*   $
��Left=�6B   $��
624,50,0,0q�6]   $	��Top=�6q   �� 5'   
   -   5        $ MaxSmtpRcptlabel��5'      $��Max Smtp Rcpt��6*   $
��Left=�6B   $��
624,82,0,0q�6]   $	��Top=�6q   �� 5(   
   -   5        $ BannerDelaylabel��5(      $��Banner Delay��6*   $
��Left=�6A   $��624,114,0,0q�6\   $	��Top=�6q   �� 5)   
   -    5        $ MaxSmtpVrfytextBox��5)      $
��Left=�6.   $��18��6I   $��
726,54,0,0q�6U   $
 Wrap=�6i   $��0��6}   $	��Top=�6�   $	��120��6�   �� 5*   
   -!   5        $ MaxSmtpRcpttextBox��5*      $
��Left=�6.   $��18��6I   $��
726,86,0,0q�6U   $
 Wrap=�6i   $��0��6}   $	��Top=�6�   $	��120��6�   �� 5+   
   -"   5        $ BannerDelaytextBox��5+      $
��Left=�6.   $��18��6I   $��726,118,0,0q�6U   $
 Wrap=�6j   $��0��6~   $	��Top=�6�   $	��120��6�   �� 5,   
   -#   5        $ 
ErrorDelay��5,      $��Error Delay��6$   $
��Left=�6:   $��624,147,0,0q�6U   $	��Top=�6j   �� 5-   
   -$   5        $ LocalDomainslabel��5-      $��Local Domains��6+   $
��Left=�6C   $��624,182,0,0q�6^   $	��Top=�6s   �� 5.   
   -%   5        $ LocalMailBoxeslabel��5.      $��Local Mail Boxes��6-   $
��Left=�6H   $��624,214,0,0q�6c   $	��Top=�6x   �� 5/   
   -&   5        $ ErrorDelaytextBox��5/      $
��Left=�6-   $��18��6H   $��726,147,0,0q�6T   $
 Wrap=�6i   $��0��6}   $	��Top=�6�   $	��120��6�   �� 50   
   -'   5        $ LocalDomainstextBox��50      $
��Left=�6/   $��18��6J   $��726,185,0,0q�6V   $
 Wrap=�6k   $�� ��6   $	��Top=�6�   $	��120��6�   �� 51   
   -(   5        $ LocalMailBoxestextBox��51      $
��Left=�61   $��18��6L   $��726,222,0,0q�6X   $
 Wrap=�6m   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 52   
   -)   5        $ DoTempFaillabel��52      $��Do Temp Fail��6)   $
��Left=�6@   $��
10,147,0,0q�6[   $	��Top=�6o   �� 53   
   -*   5        $ StoreDatalabel��53      $��
Store Data��6(   $
��Left=�6=   $��
10,182,0,0q�6X   $	��Top=�6l   �� 54   
   -+   5         ��Name$ DoTempFailcheckBox��54      $�� ��6/   $
��Left=�6:   $��117,154,0,0q�6U   $	��Top=�6j   �� 55   
   -,   5        $ StoreDatacheckBox��55      $�� ��6.   $
��Left=�69   $��117,188,0,0q�6T   $	��Top=�6i    d� 	IsChecked$
 TrueY�6�   �� 56   
   --   5        $ VerboseLoggingcheckBox��56      $�� ��63   $
��Left=�6>   $��373,122,0,0q�6Y   $	��Top=�6n   �� 57   
   -.   5        $ DoEarlyTalkcheckBox��57      $�� ��60   $
��Left=�6;   $��373,147,0,0q�6V   $	��Top=�6k   �� 58   
   -/   5         ��Name$ okbutton��58      $��OK��6#   $
��Left=�60   $��439,284,0,0q�6K   $	��Top=�6`   $��75��6x   6�   �� 59   
   -0   5        $ browse2��59      $��Brows��6"   $
��Left=�62   $��
512,85,0,0q�6M   $	��Top=�6a   $��75��6y   6�   �� 5:   
   -1   5        $ browse1��5:      $��Brows��6"   $
��Left=�62   $��
512,21,0,0q�6M   $	��Top=�6a   $��75��6y   6�   5<      5=      