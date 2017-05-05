SSIS_SSH_Components
===================

SSH Components for SSIS. Use at your own risk. These components allow SSIS packages to execute shell commands and also perform SSH file transfers on remote servers.

SSIS SSH Components

This package consists of two SSIS control flow tasks and one connection manager.

This is the connection manager. Pretty self explanatory.
![Image of Connection Manager](https://raw.githubusercontent.com/nkuebler000/SSIS_SSH_Components/master/connection_manager.png)

This is the execute command task. The command text is executed one line at a time on the host defined by the selected connection manager.
![Image of Execute Command Task](https://raw.githubusercontent.com/nkuebler000/SSIS_SSH_Components/master/execute_command_task.png)

This is the SFTP task in receive mode. The source file is downloaded from the host defined by the SSH Connection Manager to the directory defined by the Destination Connection Manager.
![Image of FTP Receive Task](https://raw.githubusercontent.com/nkuebler000/SSIS_SSH_Components/master/ftp_receive.png)

This is the SFTP task in send mode. The source file is uploaded to the host defined by the SSH Connection Manager from the directory defined by the Source Connection Manager. The uploaded file is placed in the Send Files Destination Directory on the host defined by the SSH Connection Manager.
![Image of FTP Send Task](https://raw.githubusercontent.com/nkuebler000/SSIS_SSH_Components/master/ftp_send.png)
