<template>
    <div class="main">
        <div class="header">
            <h1 style="text-align: center">
                Calcule a quantidade de litros para pintar 4 paredes!
            </h1>
        </div>
        <div class="main-content">
            <wallcard
                title="Parede 1"
                @height="(val) => (walls.firstWall.height = val)"
                @width="(val) => (walls.firstWall.width = val)"
                @doors="(val) => (walls.firstWall.doors = val)"
                @windows="(val) => (walls.firstWall.windows = val)"
            />
            <wallcard
                title="Parede 2"
                @height="(val) => (walls.secondWall.height = val)"
                @width="(val) => (walls.secondWall.width = val)"
                @doors="(val) => (walls.secondWall.doors = val)"
                @windows="(val) => (walls.secondWall.windows = val)"
            />
            <wallcard
                title="Parede 3"
                @height="(val) => (walls.thirdWall.height = val)"
                @width="(val) => (walls.thirdWall.width = val)"
                @doors="(val) => (walls.thirdWall.doors = val)"
                @windows="(val) => (walls.thirdWall.windows = val)"
            />
            <wallcard
                title="Parede 4"
                @height="(val) => (walls.fourthWall.height = val)"
                @width="(val) => (walls.fourthWall.width = val)"
                @doors="(val) => (walls.fourthWall.doors = val)"
                @windows="(val) => (walls.fourthWall.windows = val)"
            />
        </div>
        <div class="action">
            <button-custom text="Calcular" @clicked="calculate" />
        </div>
        <div v-if="!!cans.totalSquareMeter || fail" class="footer">
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
                        {{ cans.totalSquareMeter }}</span
                    >
                </div>
                <div class="info-two">
                    <span
                        ><strong>Total de litros:</strong>
                        {{ cans.totalLiters }}</span
                    >
                </div>
                <div class="info-three">
                    <span><strong>Latas:</strong></span>
                    <ul>
                        <li v-for="(can, index) in cans.cans" :key="index">
                            {{ can.quantity }}x {{ can.liters }} L
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import Walls from "@/models/Walls";
import Cans from "@/models/Cans";
import paintService from "@/services/paint-service";
import ButtonCustom from "@/components/buttons/buttons/button/ButtonCustom.vue";
import wallcard from "@/components/cards/wallcard/wallcard.vue";

export default {
    name: "MainPage",
    data() {
        return {
            teste: "",
            fail: false,
            occurrences: "",
            walls: new Walls(),
            cans: new Cans(),
        };
    },
    components: {
        ButtonCustom,
        wallcard,
    },

    methods: {
        calculate() {
            // validar cadastro
            this.fail = false;
            this.occurrences = "";

            paintService
                .calculate(this.walls)
                .then((result) => {
                    console.log(result);
                    this.cans = new Cans(result.data);
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
