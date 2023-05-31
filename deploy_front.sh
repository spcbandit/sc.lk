#!/bin/bash
cd ${DEPLOY_DIR}

docker login -u ${CI_REGISTRY_USER} -p ${CI_JOB_TOKEN} ${CI_REGISTRY}
docker pull ${CI_REGISTRY_IMAGE}/${CI_COMMIT_REF_NAME}:${CI_PIPELINE_ID}-front
docker network create --driver overlay internal-net || true
envsubst < docker-compose-front.tpl > docker-compose.yaml
cat docker-compose.yaml
docker stack deploy --with-registry-auth --compose-file docker-compose.yaml ${PROJECT_NAME}-${CI_COMMIT_REF_NAME}

cd
rm -rf ${DEPLOY_DIR}
