# # Stage 1: Compile and Build angular codebase

# # Use official node image as the base image
# FROM node:8.9.0 as build

# # Set the working directory
# WORKDIR /usr/local/app

# # Add the source code to app
# COPY ./ /usr/local/app/
# COPY ./node_modules /usr/local/app/node_modules

# # Install all the dependencies
# # RUN npm install

# # Generate the build of the application
# RUN npm run build


# # Stage 2: Serve app with nginx server

# # Use official nginx image as the base image
# FROM nginx:latest
# COPY nginx.conf /etc/nginx/
# # Copy the build output to replace the default nginx contents.
# COPY --from=build /usr/local/app/dist/KsApp /usr/share/nginx/html

FROM node:12.20.0

# Install global npm packages
RUN npm i -g @angular/cli

# Set working directory
WORKDIR /usr/src/app


# Copy the remaining source code
COPY . .
RUN echo ls