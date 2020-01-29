# POC-Stone
Prova de conceito
      
      Para acessar a api é so acessar o endereço.
      http://35.188.107.134:82/swagger/index.html

      docker pull cbuenohub/pocstone:poc
      
#Para subir o container sugiro rodar o compose do mongo da maneira como está abaixo.
  Este Compose sobre o mongo e o mongo express
  
                        version: '3.7'
                        services:
                           mongo:
                              image: mongo
                              container_name: mongodb_server
                              restart: always
                              ports:
                                 - 127.0.0.1:27017:27017
                              environment:
                                 MONGO_INITDB_ROOT_USERNAME: pocstone
                                 MONGO_INITDB_ROOT_PASSWORD: pocstone
                              networks:
                                - mongo_net
                           mongo-express:
                              image: mongo-express
                              container_name: mongo-express
                              restart: always
                              ports:
                                 - 127.0.0.1:8081:8081
                              environment:
                                 ME_CONFIG_MONGODB_ADMINUSERNAME: pocstone
                                 ME_CONFIG_MONGODB_ADMINPASSWORD: pocstone
                              networks:
                                - mongo_net        

                        networks:
                          mongo_net:
                            driver: brid
#Após subir o mongo vamos rodar o container criado chamado PocApi
                     
         # opcional - docker pull cbuenohub/pocstone
         docker run -p 82:82 --link mongodb_server:mongodb_server --name pocapi -it --net mongocompose_mongo_net  cbuenohub/pocstone:poc
