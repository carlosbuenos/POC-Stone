# POC-Stone
Prova de conceito
    

      docker pull cbuenohub/pocstone:postgres
      
#Para subir o container sugiro rodar o compose do mongo da maneira como está abaixo.
  Este Compose sobre o mongo e o mongo express
  
                        version: '3.1'

                        services:

                          db:
                            image: postgres:alpine
                            restart: always
                            environment:
                              POSTGRES_USER: pocstone
                              POSTGRES_PASSWORD: pocstone
                            ports:
                              - 5432:5432

                          adminer:
                            image: adminer
                            restart: always
                            ports:
                              - 8080:8080
#Após subir o mongo vamos rodar o container criado chamado PocApi
                     
         # opcional - docker pull cbuenohub/pocstone:postgres
        
