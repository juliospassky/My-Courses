Lista de Comandos Úteis

1- Remover todos os containers: docker rm $(docker ps -a -q)
2- Remover todas as imagens: docker rmi $(docker images -q)
3- Parar todos os containers: docker kill $(docker ps -q)
