version: '3.7'
services:

  app_back:
    image: ${CI_REGISTRY_IMAGE}/${CI_COMMIT_REF_NAME}:${CI_PIPELINE_ID}-back
    environment:
      - ASPNETCORE_URLS=http://0.0.0.0:5247
    networks:
      - traefik-net
      - internal-net
    deploy:
      mode: replicated
      replicas: 1
      restart_policy:
        condition: any
        delay: 5s
        max_attempts: 5
        window: 10s
      labels:
        - "traefik.enable=true"
        - "traefik.docker.network=traefik-net"
        - "traefik.http.routers.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}.rule=Host(`${PROJECT_DOMAIN}`)"
        - "traefik.http.services.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}.loadbalancer.server.port=5247"
        - "traefik.http.routers.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}.entrypoints=websecure"
        - "traefik.http.routers.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}.tls.certresolver=myresolver"
        - "traefik.http.routers.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}.middlewares=${PROJECT_NAME}-${CI_COMMIT_REF_NAME}-https,${PROJECT_NAME}-${CI_COMMIT_REF_NAME}-serviceheaders"
        - "traefik.http.middlewares.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}-https.redirectscheme.scheme=https"
        - "traefik.http.middlewares.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}-serviceheaders.headers.accesscontrolallowmethods=GET,PUT,POST,DELETE,PATCH,OPTIONS"
        - "traefik.http.middlewares.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}-serviceheaders.headers.accesscontrolallowheaders=Origin,X-Requested-With,Content-Type,ContentType,Accept,Authorization"
        - "traefik.http.middlewares.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}-serviceheaders.headers.accesscontrolalloworiginlist=*"
        - "traefik.http.middlewares.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}-serviceheaders.headers.accesscontrolmaxage=100"
        - "traefik.http.middlewares.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}-serviceheaders.headers.addvaryheader=true"
    logging:
      driver: gelf
      options:
        gelf-address: udp://log.it.scancity.ru:12202
        tag: app-${PROJECT_NAME}-${CI_COMMIT_REF_NAME}

networks:
  traefik-net:
    driver: overlay
    external: true
  internal-net:
    driver: overlay
    external: true

