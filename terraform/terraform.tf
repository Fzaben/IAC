provider "digitalocean" {}

variable "ssh_name" {
  type        = string
  description = "Your DigitalOcean API token"
}

variable "do_token" {
  type        = string
  description = "Your DigitalOcean API token"
}


variable "pub_key" {
  type        = string
  description = "The path to your public SSH key"
}

variable "pvt_key" {
  type        = string
  description = "The path to your private SSH key"
}

variable "droplet_name" {
  type        = string
  description = "The droplet name"
}

variable "droplet_size" {
  type        = string
  description = "The domain it self subdomain"
}

variable "droplet_image" {
  type        = string
  description = "The domain it self subdomain"
}

variable "region" {
  type        = string
  description = "The data center region of your droplet "
}

variable "domain" {
  type        = string
  description = "The domain it self subdomain"
}

variable "auth_subdomain" {
  type        = string
  description = "The domain it self subdomain"
}

variable "api_subdomain" {
  type        = string
  description = "The domain it self subdomain"
}

variable "landing_subdomain" {
  type        = string
  description = "The domain it self subdomain"
}