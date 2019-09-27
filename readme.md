install linux
wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

sudo add-apt-repository universe
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-sdk-2.2

or look here http://codeandinterests.com/2018/10/31/asp-net-core-with-apache-on-ubuntu/

install windows 
https://dotnet.microsoft.com/download

