version: '3.7'
services:

  app_front:
    image: ${CI_REGISTRY_IMAGE}/${CI_COMMIT_REF_NAME}:${CI_PIPELINE_ID}-front
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
        - "traefik.http.routers.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}-front.rule=Host(`${PROJECT_DOMAIN}`)"
        - "traefik.http.services.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}-front.loadbalancer.server.port=80"
        - "traefik.http.routers.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}-front.entrypoints=websecure"
        - "traefik.http.routers.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}-front.tls.certresolver=myresolver"
        - "traefik.http.routers.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}-front.middlewares=${PROJECT_NAME}-${CI_COMMIT_REF_NAME}-front-https"
        - "traefik.http.middlewares.${PROJECT_NAME}-${CI_COMMIT_REF_NAME}-front-https.redirectscheme.scheme=https"
        - "traefik.docker.network=traefik-net"
    logging:
      driver: gelf
      options:
        gelf-address: udp://51.250.22.211:12201
        tag: app-${PROJECT_NAME}-${CI_COMMIT_REF_NAME}-front

networks:
  traefik-net:
    driver: overlay
    external: true
  internal-net:
    driver: overlay
    external: true
