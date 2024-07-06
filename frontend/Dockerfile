# Use uma imagem do Node.js como base
FROM node:18 AS build
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build --prod

# Use uma imagem do Nginx para servir o aplicativo
FROM nginx:alpine
COPY --from=build /app/dist/localforecast53 /usr/share/nginx/html
EXPOSE 80

