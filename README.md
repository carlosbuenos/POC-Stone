# POC-Stone
Prova de conceito
    

      docker pull cbuenohub/pocstone:postgres
      
#Para subir o container sugiro rodar o compose do postgres da maneira como está abaixo.
  Este Compose sobre o postgres e o adminer que permite manipulação através de ferramenta visual pelo navegador..

          version: '3.1'
          services:
            db:
              image: postgres:alpine
              container_name: postgres_server
              restart: always
              environment:
                POSTGRES_USER: pocstone
                POSTGRES_PASSWORD: pocstone
              ports:
                - 5432:5432
              networks: 
                - postgrenet

            adminer:
              image: adminer
              container_name: adminer
              restart: always
              ports:
                - 8080:8080
              networks: 
                - postgrenet

          networks:
            postgrenet:
              driver: bridge  
          
#Após subir o postgre e o Adminer vamos subir a imagem da api PocApi
                     
     # opcional - docker pull cbuenohub/pocstone:postgres
     # docker run -p 82:82 --link postgres_server:postgres_server --name pocapi -it --net postgrecompose_postgrenet cbuenohub/pocstone:postgres

