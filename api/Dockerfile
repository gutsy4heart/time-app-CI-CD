FROM node:alpine

WORKDIR /app

EXPOSE 5006

COPY package*.json .

RUN npm install

COPY . .

CMD ["npm", "run", "dev"]