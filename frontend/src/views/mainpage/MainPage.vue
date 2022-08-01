<template>
    <div class="main">
        <div class="header">
            <h1 style="text-align: center">
                Calcule a quantidade de litros para pintar 4 paredes!
            </h1>
        </div>
        <div class="main-content">
            <div class="card">
                <div class="header">
                    <title-page text="Parede 1" />
                </div>
                <div class="content">
                    <div class="row">
                        <div class="field">
                            <InputLabel
                                label="Altura (centímetro)"
                                type="number"
                                v-model="walls.firstWall.height"
                            />
                        </div>
                        <div class="field">
                            <InputLabel
                                label="Largura (centímetro)"
                                type="number"
                                v-model="walls.firstWall.width"
                            />
                        </div>
                        <div class="field">
                            <InputLabel
                                label="Portas"
                                type="Number"
                                v-model="walls.firstWall.doors"
                            />
                        </div>
                        <div class="field">
                            <InputLabel
                                label="Janelas"
                                type="Number"
                                v-model="walls.firstWall.windows"
                            />
                        </div>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="header">
                    <title-page text="Parede 2" />
                </div>
                <div class="content">
                    <div class="row">
                        <div class="field">
                            <InputLabel
                                label="Altura (centímetro)"
                                type="number"
                                v-model="walls.secondWall.height"
                            />
                        </div>
                        <div class="field">
                            <InputLabel
                                label="Largura (centímetro)"
                                type="number"
                                v-model="walls.secondWall.width"
                            />
                        </div>
                        <div class="field">
                            <InputLabel
                                label="Portas"
                                type="Number"
                                v-model="walls.secondWall.doors"
                            />
                        </div>
                        <div class="field">
                            <InputLabel
                                label="Janelas"
                                type="Number"
                                v-model="walls.secondWall.windows"
                            />
                        </div>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="header">
                    <title-page text="Parede 3" />
                </div>
                <div class="content">
                    <div class="row">
                        <div class="field">
                            <InputLabel
                                label="Altura (centímetro)"
                                type="number"
                                v-model="walls.thirdWall.height"
                            />
                        </div>
                        <div class="field">
                            <InputLabel
                                label="Largura (centímetro)"
                                type="number"
                                v-model="walls.thirdWall.width"
                            />
                        </div>
                        <div class="field">
                            <InputLabel
                                label="Portas"
                                type="Number"
                                v-model="walls.thirdWall.doors"
                            />
                        </div>
                        <div class="field">
                            <InputLabel
                                label="Janelas"
                                type="Number"
                                v-model="walls.thirdWall.windows"
                            />
                        </div>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="header">
                    <title-page text="Parede 4" />
                </div>
                <div class="content">
                    <div class="row">
                        <div class="field">
                            <InputLabel
                                label="Altura (centímetro)"
                                type="number"
                                v-model="walls.fourthWall.height"
                            />
                        </div>
                        <div class="field">
                            <InputLabel
                                label="Largura (centímetro)"
                                type="number"
                                v-model="walls.fourthWall.width"
                            />
                        </div>
                        <div class="field">
                            <InputLabel
                                label="Portas"
                                type="Number"
                                v-model="walls.fourthWall.doors"
                            />
                        </div>
                        <div class="field">
                            <InputLabel
                                label="Janelas"
                                type="Number"
                                v-model="walls.fourthWall.windows"
                            />
                        </div>
                    </div>
                </div>
            </div>
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
import InputLabel from "@/components/inputs/input/InputLabel.vue";
import TitlePage from "@/components/titles/title/TitlePage.vue";
import Walls from "@/models/Walls";
import Cans from "@/models/Cans";
import paintService from "@/services/paint-service";
import ButtonCustom from "@/components/buttons/buttons/button/ButtonCustom.vue";

export default {
    name: "MainPage",
    data() {
        return {
            teste: "2",
            fail: false,
            occurrences: "",
            walls: new Walls(),
            cans: new Cans(),
        };
    },
    components: {
        InputLabel,
        TitlePage,
        ButtonCustom,
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
