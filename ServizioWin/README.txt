

Aprire SERVICES console:

services.msc dal menu esegui

---------------------------------------------

INSTALLARE SERVIZIO:

InstallUtil <serviceName.exe> 
InstallUtil <serviceName.exe>  -u per disinstallarlo

----------------------------------------------

PER DEBUGGARE IL SERVZIO FARE COSÌ:

1) Avviare il servzio dal Services Manager
2) Individuare il servizio in esecuzione (è il nome del file eseguibile, in questo caso: ServizioWin.exe) oppure da Task Manger individuare il PID del servzio in esecuzione (nel tab Servizi) 
3) Menu DEBUG --> Attach to Process --> selezionare il servizio in esecuzione tramite il PID (selezionare Codice managed 4.0, 4.5, 4.6)
4) Fare il debug normalmente

