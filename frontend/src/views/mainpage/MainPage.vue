<template>
    <div class="main">
        <div class="header">
            <h1 style="text-align: center">
                Calcule a quantidade de litros para pintar 4 paredes!
            </h1>
        </div>
        <div class="main-content">
            <wallcard title="Parede 1" v-model="walls.firstWall" />
            <wallcard title="Parede 2" v-model="walls.secondWall" />
            <wallcard title="Parede 3" v-model="walls.thirdWall" />
            <wallcard title="Parede 4" v-model="walls.fourthWall" />
        </div>
        <div class="action">
            <button-custom text="Calcular" @clicked="calculate" />
        </div>
        <div v-if="!!cansNeeded.totalSquareMeter || fail" class="footer">
            <div class="footer-header">
                <h4>Resultado</h4>
            </div>
            <div v-if="fail" class="footer-fail">
                <p>Falha ao realizar o cálculo:</p>
                <ul>
                    <li v-for="(occurrence, index) in occurrences" :key="index">
                        {{ occurrence }}
                    </li>
                </ul>
            </div>

            <div v-else class="footer-content">
                <div class="info-one">
                    <span
                        ><strong>M² total:</strong>
                        {{ cansNeeded.totalSquareMeter }}</span
                    >
                </div>
                <div class="info-two">
                    <span
                        ><strong>Total de litros:</strong>
                        {{ cansNeeded.totalLiters }}</span
                    >
                </div>
                <div class="info-three">
                    <span><strong>Latas:</strong></span>
                    <ul>
                        <li
                            v-for="(cansNeeded, index) in cansNeeded.cans"
                            :key="index"
                        >
                            {{ cansNeeded.quantity }}x {{ cansNeeded.liters }} L
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import Walls from "@/models/Walls";
import CansNeeded from "@/models/CansNeeded";
import paintService from "@/services/paint-service";
import ButtonCustom from "@/components/buttons/buttons/button/ButtonCustom.vue";
import wallcard from "@/components/cards/wallcard/wallcard.vue";

export default {
    name: "MainPage",
    data() {
        return {
            fail: false,
            occurrences: "",
            walls: new Walls(),
            cansNeeded: new CansNeeded(),
        };
    },
    components: {
        ButtonCustom,
        wallcard,
    },
    watch: {
        walls(newValue) {
            console.log("walls alterado");
            console.log(newValue);
        },
    },
    methods: {
        calculate() {
            // console.log(this.walls);

            // // validar cadastro
            this.fail = false;
            this.occurrences = "";

            paintService
                .calculate(this.walls)
                .then((result) => {
                    this.cansNeeded = new CansNeeded(result.data);
                })
                .catch((err) => {
                    console.log(err.response.data.occurrences);
                    this.occurrences = err.response.data.occurrences;
                    this.fail = true;
                });
        },
    },
};
</script>

<style lang="scss" src="./style.scss" scoped />
