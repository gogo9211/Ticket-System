<template>
	<div id="login-frame">
		<h1 style="color: white">Login</h1>
        <input type="text" v-model="username" placeholder="Username">
        <input style="margin-top: 10px" v-model="password" type="password" placeholder="Password">
        <br>
        <button @click="login" style="margin-top: 15px">Login</button>
	</div>
</template>

<script>
export default {
	name: 'Login',
    data() {
        return {
            'username': '',
            'password': ''
        }
    },
    methods: {
        login() {
            console.log(this.username, this.password);
        }
    }
}
</script>

<style scoped>
button {
    margin-top: 10px;
    width: 120px;
    background-color: rgb(25, 25, 25);
    color: white;
    border: none;
    border-radius: 5px;
    padding: 10px;
    font-size: 16px;
    cursor: pointer;
}

input {
    text-align: center;
    width: 280px;
    height: 35px;
    border: none;
    border-radius: 3px;
    background-color: rgb(25, 25, 25);
    color: white;
    font-size: 17px;
}

#login-frame {
    text-align: center;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    width: 470px;
    height: 235px;
    background-color: rgb(35, 35, 35);
    border-radius: 3px;
}
</style>