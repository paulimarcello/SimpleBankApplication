# this Vagrantbox is used for development purposes
# within that machine you can ...
# ... build docker images locally (simulates ci buildprocess)
# ... start a docker image or a docker stack (docker compose)

Vagrant.configure(2) do |config|

  config.vm.box = "ubuntu/trusty64"

  config.vm.provider "virtualbox" do |vb|
    vb.memory = "1024"
    vb.name = "machine for SimpleBankApp"
  end

  config.vm.synced_folder "./src/", "/src"

  config.vm.network "forwarded_port", guest: 5000, host: 8080

  config.vm.provision :shell, inline: <<-SHELL
    sudo apt-get update

    #docker
    curl -sSL https://get.docker.com/ | sh
  	#adding user vagrant to dockergroup to execute commands without sudo
  	sudo usermod -aG docker vagrant

    #.net core fur Ubuntu 14.04
    sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list'
    sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893
    sudo apt-get update
    sudo apt-get install -y dotnet-dev-1.0.1

  SHELL

end