Vagrant.configure(2) do |config|

  config.vm.box = "ubuntu/trusty64"

  config.vm.provider "virtualbox" do |vb|
    vb.memory = "1024"
  end

  config.vm.synced_folder "./src/", "/code"

  #config.vm.network "public_network", ip: "192.168.178.123"
  # app only temp.
  config.vm.network "forwarded_port", guest: 5000, host: 8080

  config.vm.provision :shell, inline: <<-SHELL
    sudo apt-get update

    #docker
    curl -sSL https://get.docker.com/ | sh
    #adding user vagrant to dockergroup to execute commands without sudo
    sudo usermod -aG docker vagrant
  SHELL

end